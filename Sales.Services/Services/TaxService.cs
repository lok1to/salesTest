using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Services
{
    public class TaxService : ITaxService
    {
        private readonly IRepository<Tax> _taxRepository;
        public TaxService(IRepository<Tax> taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public void AddTax(Tax tax)
        {
            //TODO: add logic to set endDate to current tax
            _taxRepository.Insert(tax);
        }

        public Tax Find(int id)
        {
            return _taxRepository.GetById(id);
        }

        public IEnumerable<Tax> GetTaxes()
        {
            return _taxRepository.GetAll;
        }

        public void Insert(Tax model)
        {
            _taxRepository.Insert(model);
        }
    }
}
