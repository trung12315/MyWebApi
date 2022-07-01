using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface ICategoryRepository
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Add(CategoryModel category);
        void Update(CategoryViewModel category);
        void Delete(int id);
    }
}
