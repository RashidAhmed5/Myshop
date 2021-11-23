using Microsoft.EntityFrameworkCore;


namespace MyStore.Services.DBModels
{
    public partial class MyStoreDBContext: DbContext
    {
        public MyStoreDBContext() : base()
        { }
        public MyStoreDBContext(DbContextOptions<MyStoreDBContext> options) : base(options)
        { }

  
            public virtual DbSet<ProductCategory> ProductCategory { get; set; }          
            
        }
    }
