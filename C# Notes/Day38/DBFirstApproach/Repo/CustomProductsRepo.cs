using DBFirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBFirstApproach.Repo
{
    internal class CustomProductsRepo : ICustomProduct
    {
        private readonly NorthWindContext _context;

        // Fix: Constructor name must match Class name
        public CustomProductsRepo(NorthWindContext context)
        {
            _context = context;
        }

        // Fix: Added 'async' and corrected method name to AddAsync
        public async Task<CustomProduct> AddAsync(CustomProduct product)
        {
            await _context.CustomProducts.AddAsync(product);
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.CustomProducts.FindAsync(id);
            if (product != null)
            {
                _context.CustomProducts.Remove(product);
                // Note: Changes aren't permanent until SaveChangesAsync() is called
            }
        }

        public async Task<List<CustomProduct>> GetAllAsync()
        {
            return await _context.CustomProducts.ToListAsync();
        }

        public async Task<CustomProduct?> GetByIdAsync(int id)
        {
            // Simplified logic using FindAsync
            return await _context.CustomProducts.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            // Fix: DbContext uses SaveChangesAsync(), not SaveChanges() for async tasks
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomProduct product)
        {
            _context.CustomProducts.Update(product);
            await Task.CompletedTask; // Since Update isn't inherently async in EF Core
        }
    }
}