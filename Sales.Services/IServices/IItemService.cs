using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.IServices
{
    public interface IItemService
    {
        void AddItem(Item item);
        IEnumerable<Item> GetItems();
        Item Find(int id);
        void Insert(Item model);
        void Update(Item model);
    }
}
