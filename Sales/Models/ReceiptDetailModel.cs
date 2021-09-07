using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class ReceiptDetailModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual ItemModel Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
    }
}