using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.IServices
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetCategories();
        Category Find(int id);
        void Insert(Category model);
    }
}
