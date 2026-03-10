using DBFirstDemo.Models;
using DBFirstDemo.Repo;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DBFirstDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using NorthwndContext cnt = new NorthwndContext();

            CustomProductsRepo obj = new CustomProductsRepo(cnt);

            var pro1 = new CustomProduct
            {
                Name = "lol",
                Stock = 69,
                Price = 69.69M
            };

            await obj.AddProduct(pro1);
            await obj.SaveProduct();

            var allProduct = await obj.GetAll();

            var toChange = await obj.GetById(1);
            if (allProduct != null)
            {
                toChange.Name = "LMFAO";
            }
            obj.UpdateProduct(toChange);

            await obj.DeleteById(1);

            foreach (var item in allProduct)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}