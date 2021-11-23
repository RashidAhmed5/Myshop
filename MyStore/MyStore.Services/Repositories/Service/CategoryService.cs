using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyStore.Services.DBModels;
using MyStore.Services.Repositories.Service;
using MyStore.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services.Repositories.Service
{
    public class CategoryService : BaseService<CategoryService>, ICategory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CategoryService(MyStoreDBContext dbContext
       , ILogger<CategoryService> logger
       , IServiceScopeFactory serviceScopeFactory) : base(dbContext, logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
           
        }


        public async Task<bool> Add(ProductCategory category)
        {
            try
            {
                LOGGER.LogInformation("Creating New Categoru :" + category.Name);
           
            using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetService<MyStoreDBContext>();

            var reguser = await dbContext.ProductCategory.SingleOrDefaultAsync(d => d.Name == category.Name);

            if (reguser != null)
            {
               return false;// return (ErrorCodes.EXCEPTION.WithMessage("User with that Referral ID already exist"), null);
            }
            await dbContext.ProductCategory.AddAsync(category);

            await dbContext.SaveChangesAsync();


            return true;
        }
            catch (Exception ex)
            {
                LOGGER.LogError("Error Occured while Creating User " + ex.Message);
                return true;
            }
}
       
        public async Task<bool> Update(ProductCategory category)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetService<MyStoreDBContext>();

            ProductCategory db_Category = await dbContext.ProductCategory.FirstOrDefaultAsync(d => d.ID == category.ID);

            if (db_Category != null)
            {
                db_Category.Name = category.Name;
                db_Category.Description = category.Description;

            }

            await dbContext.SaveChangesAsync();

            return true;
        }



        
        public async Task<List<ProductCategory>> GetCategories(string searchvalue, int pageIndex, int pageSize)
        {

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetService<MyStoreDBContext>();

                var lstcategory = await dbContext.ProductCategory.ToListAsync();

                if (!string.IsNullOrEmpty(searchvalue))
                {
                    lstcategory = lstcategory.Where(drv => drv.Name.Contains(searchvalue) || drv.Description.Contains(searchvalue)).ToList();
                }
                int TotalRecords = lstcategory.Count();
                return lstcategory.Distinct().OrderByDescending(drv => drv.ID).Skip(pageIndex).Take(pageSize).ToList();

               // return new PageList<Division>(pageIndex, pageSize, TotalRecords, lstDivision);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               // dbSession.Dispose();
            }
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategory> Get(int id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetService<MyStoreDBContext>();

            return  await dbContext.ProductCategory.SingleOrDefaultAsync(d => d.ID == id);
        }

        public Task<List<ProductCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
