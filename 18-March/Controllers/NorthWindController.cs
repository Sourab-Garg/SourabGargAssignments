using Microsoft.AspNetCore.Mvc;
using ASPDBFirstEF.Models;
using System.Runtime.CompilerServices;

namespace ASPDBFirstEF.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult SpainCustomers()
        {
            NorthwndContext cnt = new NorthwndContext();
            var spaincustomers = cnt.Customers
                    .Where(c => c.Country == "Spain")
                    .Select(x => new SpainCustomerVM
                    {
                        cid = x.CustomerId,
                        cname = x.ContactName,
                        comname = x.CompanyName
                    })
                    .ToList();

            return View(spaincustomers);
        }

        public IActionResult searchCustomer(string contactname)
        {
            NorthwndContext cnt = new NorthwndContext();
            var searchCustomer = cnt.Customers
                                .Where(x => x.ContactName == contactname)
                                .Select(x => new Customer
                                {
                                    ContactName = x.ContactName,
                                    ContactTitle = x.ContactTitle,
                                    CompanyName = x.CompanyName
                                }).SingleOrDefault();

            return View(searchCustomer);
        }   
        public ActionResult ProductsInCategory(String categoryname)
        {
            NorthwndContext cnt = new NorthwndContext();
            var productsinCategory = cnt.Products.
                                     Where(x => x.Category.CategoryName == categoryname).
                                        Select(x => new ProdCat
                                        {
                                            prodname = x.ProductName,
                                            catname = x.Category.CategoryName,
                                        }).ToList();
            return View(productsinCategory);
        }   
        public ActionResult OrderRange(string range)
        {
            NorthwndContext cnt = new NorthwndContext();
            var orderRange = cnt.Orders
                            .Where(x => x.OrderDetails.Sum(y => y.Quantity) > int.Parse(range))
                            .Select(x => new OrderQ
                            {
                                Id = x.OrderId,
                                OrderDate = x.OrderDate,
                                TotalQuantity = x.OrderDetails.Sum(y => y.Quantity)
                            }).ToList();
            return View(orderRange);
        }
    }
}