using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        //protected virtual object OkResponse(ErrorCode error, object data)
        //{
        //    object ok = new
        //    {
        //        error = error.ToString(),
        //        title = error.Title,
        //        message = error.Message,
        //        data
        //    };
        //    return ok;
        //}
        //protected virtual object OKJsonResponse(ErrorCode error, object data)
        //{
        //    object OK = new
        //    {
        //        error = error.ToString(),
        //        data,
        //        message = error.Message
        //    };
        //    return OK;
        //}
        //protected virtual object OkResposeList<T>(ErrorCode error, ListingVO<T> listingVO)
        //{
        //    object OK = new
        //    {
        //        listingVO.draw,
        //        data = listingVO.ObjectList,
        //        listingVO.recordsFiltered,
        //        listingVO.recordsTotal,
        //        message = error.Message
        //    };

        //    return OK;
        //}
        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }

    }
}
