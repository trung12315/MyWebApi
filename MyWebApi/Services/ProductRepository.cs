using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private MyDBContext _context;
        public static int PageSize { get; set; } = 2;
        public ProductRepository (MyDBContext context)
        {
            _context = context;
        }
        public ProductViewModel Add(ProductModel product)
        {
            var _product = new Product
            {
                Name = product.Name,
                Descrpiption=product.Description,
                Price=product.Price,
                Discount=product.Discount,
                CategoryID=product.CategoryID

            };
            _context.Add(_product);
            _context.SaveChanges();
            return new ProductViewModel
            {
                Id = _product.Id,
                Name = _product.Name,
                Descrpiption=_product.Descrpiption,
                Price=_product.Price,
                Discount=_product.Discount,
                CategoryID=_product.CategoryID
            };
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }
        public List<ProductModel> GetAll(string search, double?from, double? to,int page=1)
        {
            var allproduct = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                allproduct=allproduct.Where(p => p.Name.Contains(search));
            }
            
            if (from.HasValue)
            {
                allproduct = allproduct.Where(p => p.Price >=from);
            }
            
            if (to.HasValue)
            {
                allproduct = allproduct.Where(p => p.Price <= to);
            }
            //phan trang
            allproduct = allproduct.Skip((page - 1) * PageSize).Take(PageSize);

            var result = allproduct.Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name

            }) ;
            return result.ToList();
        }
        public ProductViewModel GetById(Guid id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product != null)
            {
                return new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Descrpiption = product.Descrpiption,
                    Price = product.Price,
                    Discount = product.Discount,
                    CategoryID = product.CategoryID
                };
            }
            return null;
        }

        public void Update(ProductViewModel product)
        {
            var _product = _context.Products.SingleOrDefault(c => c.Id == product.Id);
            _product.Name = product.Name;
            _product.Descrpiption = product.Descrpiption;
            _product.Price = product.Price;
            _product.Discount = product.Discount;
            _context.SaveChanges();
        }
    }
}
