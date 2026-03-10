using CodeFirstEFDemo;
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

//var authors = await context.Authors.Include(x => x.Courses).ToListAsync();

//foreach(var a in authors)
//{
//    Console.WriteLine($"Author: {a.Name}");
//    foreach(var course in a.Courses)
//    {
//        Console.WriteLine($"{course.Title} - {course.Description} - {course.level}");
//    }
//}

//var newProduct = new Product { Name = "Smartphone", Price = 999.99M, CategoryId = 1 };
//IProductRepository obj = new  ProductRepository(context);
//await obj.AddAsync(newProduct);
////int existingId = 4;
//var toupdate = await obj.GetByIdAsync(newProduct.Id);
//if(toupdate != null)
//{
//    toupdate.Price = 399.99M;
//    toupdate.Name = "HeadPhone";
//    await obj.UpdateAsync(toupdate);
//    Console.WriteLine($"Upadte sucessfull!");
//    Console.ReadLine();
//}

//await obj.DeleteAsync(4);

IProductRepository obj2 = new ProductRepository2(context);

// 1. TEST: GetAllAsync (Using EXEC GetAllProducts)
Console.WriteLine("--- All Products ---");
var allProducts = await obj2.GetAllAsync();
foreach (var p in allProducts)
{
    Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: {p.Price}");
}

// 2. TEST: GetByIdAsync (Using EXEC GetProductById)
int testId = 4; // Targeting the Smartphone from your screenshot
var product = await obj2.GetByIdAsync(testId);

if (product != null)
{
    Console.WriteLine($"\nFound Product: {product.Name}");

    // 3. TEST: UpdateAsync (Using EXEC UpdateProduct)
    product.Name = "Gaming Smartphone";
    product.Price = 1199.99M;
    await obj2.UpdateAsync(product);
    Console.WriteLine("Update executed via Stored Procedure!");

    // 4. TEST: GetByCategoryAsync
    Console.WriteLine($"\n--- Products in Category {product.CategoryId} ---");
    var categoryProducts = await obj2.GetByCategoryAsync(product.CategoryId);
    foreach (var cp in categoryProducts)
    {
        Console.WriteLine($"- {cp.Name} (${cp.Price})");
    }

    //5.TEST: DeleteAsync(Using EXEC DeleteProduct)
     //Uncomment the lines below if you want to test deletion
    // await obj2.DeleteAsync(testId);
    //Console.WriteLine($"\nDeleted Product with ID {testId}");
}
else
{
    Console.WriteLine($"\nProduct with ID {testId} not found.");
}

Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();