using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFDemo
{
    internal class ProductRepository2 : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository2(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            // EF Core converts these interpolated values into SQL Parameters automatically
            var result = await _context.Products
                .FromSqlInterpolated($"EXEC InsertProduct {product.Name}, {product.Price}, {product.CategoryId}")
                .ToListAsync();

            return result.First();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteProduct {id}");
        }

        public async Task<List<Product>> GetAllAsync()
        {
            // No parameters needed here
            return await _context.Products.FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var products = await _context.Products
                .FromSqlInterpolated($"EXEC GetProductById {id}")
                .ToListAsync();
            
            return products.FirstOrDefault();
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateProduct {product.Id}, {product.Name}, {product.Price}, {product.CategoryId}");
        }

        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .FromSqlInterpolated($"SELECT * FROM Products WHERE CategoryId = {categoryId}")
                .ToListAsync();
        }
    }
}