using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class TaxModel
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public bool IsImportTax { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}