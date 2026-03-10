using DBFirstApproach.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBFirstApproach.Repo
{
    internal interface ICustomProduct
    {
        Task<List<CustomProduct>> GetAllAsync(); // Ensure Model name matches (CustomProduct vs CustomProducts)
        Task<CustomProduct?> GetByIdAsync(int id);
        Task<CustomProduct> AddAsync(CustomProduct product); // Renamed for consistency
        Task UpdateAsync(CustomProduct product);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}