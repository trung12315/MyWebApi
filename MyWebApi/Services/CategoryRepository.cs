using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDBContext _context;

        public CategoryRepository (MyDBContext context)
        {
            _context = context;
        }

        public CategoryViewModel Add(CategoryModel category)
        {
            var _category = new Category
            {
                Name=category.Name
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryViewModel { 
                CategoryID=_category.CategoryID,
                Name=_category.Name
            };
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<CategoryViewModel> GetAll()
        {
            var categorys = _context.Categories.Select(c => new CategoryViewModel
            {
                CategoryID=c.CategoryID,
                Name=c.Name
            });
            return categorys.ToList();
        }

        public CategoryViewModel GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (category != null)
            {
                return new CategoryViewModel
                {
                    CategoryID=category.CategoryID,
                    Name=category.Name
                };
            }
            return null;
        }

        public void Update(CategoryViewModel category)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
            category.Name = category.Name;
            _context.SaveChanges();
        }
    }
}
