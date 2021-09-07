using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual IList<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
