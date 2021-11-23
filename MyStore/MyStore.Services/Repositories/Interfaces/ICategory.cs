using MyStore.Services.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services.Repository.Interfaces
{
    public interface ICategory
    {
        public Task<bool> Add(ProductCategory category);
        public Task<bool> Update(ProductCategory category);
        public Task<bool> Delete(int id);
        public Task<ProductCategory> Get(int id);
        public Task<List<ProductCategory>> GetAll();
        public Task<List<ProductCategory>> GetCategories(string searchvalue, int pageIndex, int pageSize);

    }
}
