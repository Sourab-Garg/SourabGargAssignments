using DBFirstApproach.Models; // Matches your project structure
using DBFirstApproach.Repo;   // Matches your folder name 'Repo'
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class Program
    {
        static async Task Main(string[] args)

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // 1. Initialize the Context
            using var cnt = new NorthWindContext();

            // 2. Initialize the Repository (Using the name from your previous file)
            CustomProductsRepo obj = new CustomProductsRepo(cnt);

            // --- CREATE ---
            var newProduct = new CustomProduct // Ensure singular if that's your model name
            {
                Name = "super-widget",
                Price = 89.45M,
                Stock = 23
            };

            Console.WriteLine("Adding new product...");
            await obj.AddAsync(newProduct);
            await obj.SaveChangesAsync();

            // --- UPDATE ---
            var toUpdate = await obj.GetByIdAsync(1);
            if (toUpdate != null)
            {
                Console.WriteLine($"Updating product ID: {toUpdate.Id}");
                toUpdate.Price = 34.67M;
                toUpdate.Stock = 60;
                await obj.UpdateAsync(toUpdate);
                await obj.SaveChangesAsync();
            }

            // --- READ ALL ---
            var all = await obj.GetAllAsync();
            Console.WriteLine("\nAll products:");
            foreach (var p in all)
            {
                Console.WriteLine($"{p.Id} -- {p.Name} -- {p.Price:C} -- Stock: {p.Stock}");
            }

            // --- DELETE ---
            Console.WriteLine("\nDeleting product with ID 2...");
            await obj.DeleteAsync(2);
            await obj.SaveChangesAsync(); // Don't forget to save after delete!

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}