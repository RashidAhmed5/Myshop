using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Web.Models
{
    public class DateTimeModelBinder : IModelBinder
    {
        public static readonly Type[] SUPPORTED_DATETIME_TYPES = new Type[] { typeof(DateTime), typeof(DateTime?) };
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (!SUPPORTED_DATETIME_TYPES.Contains(bindingContext.ModelType))
            {
                return Task.CompletedTask;
            }

            var modelName = string.Empty;
            // Try to fetch the value of the argument by name
            if (!string.IsNullOrEmpty(bindingContext.BinderModelName))
            {
                modelName = bindingContext.BinderModelName;
            }
            else
            {
                modelName = bindingContext.ModelName;
            }
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var dateToParse = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(dateToParse))
            {
                return Task.CompletedTask;
            }

            var formattedDateTime = ParseDateTime(dateToParse);
            bindingContext.Result = ModelBindingResult.Success(formattedDateTime);
            return Task.CompletedTask;
        }
        static DateTime? ParseDateTime(string dateToParse)
        {
            DateTime validDate;
            if (DateTime.TryParse(dateToParse, new CultureInfo("en-US"), DateTimeStyles.None, out validDate))
            {
                return validDate;
            }
            if (DateTime.TryParse(dateToParse, new CultureInfo("de-DE"), DateTimeStyles.None, out validDate))
            {
                return validDate;
            }
            return null;
        }

    }

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) ||
                context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder();
            }

            return null;
        }
    }
}
