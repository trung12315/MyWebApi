using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
   public interface IProductRepository
    {
        List<ProductModel> GetAll(string search,double? from, double?to,int page);
        ProductViewModel GetById(Guid id);
        ProductViewModel Add(ProductModel category);
        void Update(ProductViewModel category);
        void Delete(Guid id);
    }
}
