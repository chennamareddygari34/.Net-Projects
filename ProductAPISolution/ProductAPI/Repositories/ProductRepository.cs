﻿using ProductAPI.Context;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public Product Add(Product item)
        {
            //  throw new NotImplementedException();
            _context.products.Add(item);
            _context.SaveChanges();
            return item;

        }

        public Product Delete(int key)
        {
            // throw new NotImplementedException();
            var product = Get(key);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            return null;

        }

        public Product Get(int key)
        {
            // throw new NotImplementedException();
            var product = _context.products.FirstOrDefault(prod => prod.Id == key);
            return product;
        }

        public List<Product> GetAll()
        {
            return _context.products.ToList();
        }

        public Product Update(Product item)
        {
            // throw new NotImplementedException();
            _context.Entry<Product>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
