using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var context = new AppDBContext();

// create category 

//var electronics = new Category { Name = "Electronics" };

//context.Categories.Add(electronics);
//await context.SaveChangesAsync();

//context.Products.AddRange(
//    new Product { Name = "laptop", Price = 999.78M, category = electronics },
//     new Product { Name = "Mouse", Price = 678.78M, category = electronics }
//);

//await context.SaveChangesAsync();

//var laptop = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
//laptop.Price = 7899.99M;
//await context.SaveChangesAsync();

//context.Products.Remove(laptop);
//context.SaveChanges();

var authors = await context.Authors.Include(x => x.Courses).ToListAsync();

foreach(var a in authors)
{
    Console.WriteLine($"Author: {a.Name}");
    foreach(var course in a.Courses)
    {
        Console.WriteLine($"{course.Title} - {course.Description} - {course.level}");
    }
}