using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class PurchasingPayment
    {
        public int ID { get; set; }
        public int PurchaseMasterID { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
