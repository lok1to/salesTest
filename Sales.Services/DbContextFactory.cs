using Sales.Domain;
using Sales.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services
{
    public class DbContextFactory
    {
        public static IDbContext Create()
        {
            return new SalesDbContext();
        }
    }
}
