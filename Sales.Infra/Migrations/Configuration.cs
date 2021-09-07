using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SalesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //  This method will be called after migrating to the latest version.
        protected override void Seed(SalesDbContext context)
        {
            context.Taxes.AddOrUpdate(
              p => p.Id,
              new Tax { Id = 1, Percentage = 10, StartDate = DateTime.Today, IsImportTax = false },
              new Tax { Id = 2, Percentage = 5, StartDate = DateTime.Today, IsImportTax = true }
            );

            context.Categories.AddOrUpdate(
              p => p.Id,
              new Category { Id = 1, Name = "Book", IsBasicTaxExempt = true},
              new Category { Id = 2, Name = "Food", IsBasicTaxExempt = true },
              new Category { Id = 3, Name = "Medical", IsBasicTaxExempt = true },
              new Category { Id = 4, Name = "Other", IsBasicTaxExempt = false }
            );

            context.Items.AddOrUpdate(
              p => p.Id,
              new Item { Id = 1, Name = "Harry Potter", Price = 12.49m, IsImported = false, CategoryId = 1},
              new Item { Id = 2, Name = "Chocolate bar", Price = 0.85m, IsImported = false, CategoryId = 2 },
              new Item { Id = 3, Name = "Box of Chocolates", Price = 10.00m, IsImported = true, CategoryId = 2 },
              new Item { Id = 4, Name = "Music CD", Price = 14.99m, IsImported = false, CategoryId = 4 },
              new Item { Id = 5, Name = "Bottle of perfume", Price = 47.50m, IsImported = true, CategoryId = 4 },
              new Item { Id = 6, Name = "Headache Pills", Price = 9.75m, IsImported = false, CategoryId = 3 }
            );

        }
    }
}
