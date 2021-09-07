using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.IServices
{
    public interface IReceiptService
    {
        void AddReceipt(Receipt receipt);
        IEnumerable<Receipt> GetReceipts();
        Receipt Find(int id);
        void Insert(List<int> itemIds);
    }
}
