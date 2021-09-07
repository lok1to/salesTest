using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class ReceiptModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public virtual IList<ReceiptDetailModel> ReceiptDetails { get; set; }
    }
}