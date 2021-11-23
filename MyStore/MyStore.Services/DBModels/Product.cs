using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class Product
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int ProductCategoryID { get; set; }
        public int DimenstionID { get; set; }
        public int AvailableQuantity { get; set; }
        public int Threashold { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
