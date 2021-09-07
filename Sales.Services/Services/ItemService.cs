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
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void AddItem(Item item)
        {
            _itemRepository.Insert(item);
        }

        public Item Find(int id)
        {
            return _itemRepository.GetById(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll;
        }

        public void Insert(Item model)
        {
            _itemRepository.Insert(model);
        }

        public void Update(Item model)
        {
            _itemRepository.Update(model);
        }
    }
}
