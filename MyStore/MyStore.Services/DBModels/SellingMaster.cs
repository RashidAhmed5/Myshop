using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services.DBModels
{
    public class SellingMaster
    {
        public int ID { get; set; }
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalNetAmount { get; set; }
        public int NumberOfItems { get; set; }
        public int ClientID { get; set; }
        public int TransactionTypeID { get; set; }
        public bool IsPaymentDone { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
