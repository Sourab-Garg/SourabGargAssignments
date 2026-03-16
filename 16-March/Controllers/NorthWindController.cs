using Microsoft.AspNetCore.Mvc;
using ASPDBFirstEF.Models;

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
    }
}