using DBFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo.Repo
{
    internal interface ICustomProduct
    {
        Task AddProduct(CustomProduct product);
        Task<List<CustomProduct>> GetAll();
        Task<CustomProduct?> GetById(int id);
        Task DeleteById(int id);
        void UpdateProduct(CustomProduct product);
        Task SaveProduct();
    }
}
