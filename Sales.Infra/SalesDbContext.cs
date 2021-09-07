using Sales.Domain;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infra
{
    public class SalesDbContext : DbContext, IDbContext
    {
        public SalesDbContext() : base("SalesDatabase")
        {
            Database.CreateIfNotExists();
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }

    }
}
