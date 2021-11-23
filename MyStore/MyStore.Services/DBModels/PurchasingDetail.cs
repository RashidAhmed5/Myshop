using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class PurchasingDetail
    {
        public int ID { get; set; }
        public int PurchasingMasterID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Quanity { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
