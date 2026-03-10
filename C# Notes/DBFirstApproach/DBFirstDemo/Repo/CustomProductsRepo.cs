using DBFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo.Repo
{
    internal class CustomProductsRepo : ICustomProduct
    {
        private readonly NorthwndContext _context;

        public CustomProductsRepo(NorthwndContext context)
        {
            _context = context;
        }
        public async Task AddProduct(CustomProduct product)
        {
            await _context.CustomProducts.AddAsync(product);
        }

        public async Task DeleteById(int id)
        {
            var toDelete = await _context.CustomProducts.FindAsync(id);
            if (toDelete != null)
            {
                _context.CustomProducts.Remove(toDelete);
            }
        }

        public async Task<List<CustomProduct>> GetAll()
        {
            return await _context.CustomProducts.ToListAsync();
        }

        public async Task<CustomProduct?> GetById(int id)
        {
            return await _context.CustomProducts.FindAsync(id);
        }

        public async Task SaveProduct()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateProduct(CustomProduct product)
        {
            _context.CustomProducts.Update(product);
        }
    }
}
