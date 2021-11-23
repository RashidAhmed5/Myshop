using MyStore.Services.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Services.Repository.Interfaces;
using MyStore.Services.Repositories.Service;
using System;

namespace MyStore.Services
{
   public static class StartUpDi
    {

        public static void DoCommonInjection(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MyStoreDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            }
            ));
            
            services.AddScoped(typeof(ICategory), typeof(CategoryService));


            services.AddOptions();

            services.AddSingleton(configuration);

        }
    }
}

