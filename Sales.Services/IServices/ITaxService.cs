using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.IServices
{
    public interface ITaxService
    {
        void AddTax(Tax tax);
        IEnumerable<Tax> GetTaxes();
        Tax Find(int id);
        void Insert(Tax model);
    }
}
