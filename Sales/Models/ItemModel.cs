using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
    }
}