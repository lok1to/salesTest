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
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public Category Find(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll;
        }

        public void Insert(Category model)
        {
            _categoryRepository.Insert(model);
        }
    }
}
