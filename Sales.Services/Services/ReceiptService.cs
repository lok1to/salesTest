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
    public class ReceiptService : IReceiptService
    {
        private readonly IRepository<Receipt> _receiptRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Tax> _taxRepository;
        public ReceiptService(IRepository<Receipt> receiptRepository, IRepository<Item> itemRepository, IRepository<Tax> taxRepository)
        {
            _receiptRepository = receiptRepository;
            _itemRepository = itemRepository;
            _taxRepository = taxRepository;
        }

        public void AddReceipt(Receipt receipt)
        {
            _receiptRepository.Insert(receipt);
        }

        public Receipt Find(int id)
        {
            return _receiptRepository.GetById(id);
        }

        public IEnumerable<Receipt> GetReceipts()
        {
            return _receiptRepository.GetAll;
        }

        public void Insert(List<int> itemIds)
        {
            var itemCounts = itemIds.GroupBy(x => x).ToDictionary(g=> g.Key, g => g.Count());
            var receipt = new Receipt();
            receipt.ReceiptDetails = new List<ReceiptDetail>();
            receipt.PurchaseDate = DateTime.Now;
            
            foreach (var item in itemCounts)
            {
                var itemFound = _itemRepository.GetById(item.Key);
                //TODO: BRING LATEST TAX
                var taxFound = _taxRepository.GetAll;
                var taxBasic = taxFound.Where(x => x.IsImportTax == false && x.EndDate == null).First();
                var taxImport = taxFound.Where(x => x.IsImportTax == true && x.EndDate == null).First();

                var detail = new ReceiptDetail();
                detail.Quantity = item.Value;
                detail.ItemId = itemFound.Id;
                detail.Price = itemFound.Price;

                if(!itemFound.Category.IsBasicTaxExempt)
                {
                    var taxPercentage = taxBasic.Percentage;
                    if (itemFound.IsImported)
                    {
                        taxPercentage += taxImport.Percentage;
                    }

                    detail.TaxAmount = CalculateTax(itemFound.Price, taxPercentage);
                }
                else
                {
                    if(itemFound.IsImported)
                    {
                        detail.TaxAmount = CalculateTax(itemFound.Price, taxImport.Percentage);
                    }
                }

                detail.Total = detail.Quantity * (detail.Price + detail.TaxAmount);
                receipt.Total += detail.Total;
                receipt.TotalTaxAmount += detail.TaxAmount * detail.Quantity;

                receipt.ReceiptDetails.Add(detail);
            }
            
            _receiptRepository.Insert(receipt);
        }

        private decimal CalculateTax(decimal price, decimal percentage)
        {
            return Math.Ceiling((price * (percentage / 100)) * 20) / 20;
        }
    }
}
