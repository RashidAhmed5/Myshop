using System;
using MyStore.Services;
using MyStore.Services.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MyStore.Services.Repositories.Service
{
   public abstract class BaseService<T> where T : BaseService<T>
    {

        protected readonly ILogger<T> LOGGER;

        protected readonly MyStoreDBContext DB_CONTEXT;


        protected BaseService(MyStoreDBContext dbContext, ILogger<T> logger)
        {
            LOGGER = logger;
            DB_CONTEXT = dbContext;
        }

        protected async Task<bool> IsDuplicateAsync<TEntity>(string fieldName, string value, int id = 0, MyStoreDBContext dbContext = null) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(fieldName) || string.IsNullOrWhiteSpace(value))
            {
                return false;//ErrorCodes.INVALID.WithMessage("no value provided");
            }

            try
            {
                var query = $"SELECT * FROM {typeof(TEntity).Name} WHERE {fieldName}={AddSingleQuotes(value)}";
                if (id > 0)
                {
                    query += $" and Id <> {id}";
                }

                var dbSet = (dbContext ?? DB_CONTEXT).Set<TEntity>();
                var entity = await dbSet.FromSqlRaw(query).FirstOrDefaultAsync();
                return false;
               // return entity == null ? ErrorCodes.NOT_FOUND : ErrorCodes.SUCCESS;
            }
            catch (Exception ex)
            {
                LOGGER.LogError(ex, $"{nameof(TEntity)}.isDuplicate");
                return false;
                //return ErrorCodes.EXCEPTION.WithMessage(ex.Message);
            }
        }

        public static string AddSingleQuotes(string source)
        {
            return "'" + source + "'";
        }
    }
}
