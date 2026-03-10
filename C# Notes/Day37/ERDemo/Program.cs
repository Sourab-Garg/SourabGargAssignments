using ERDemo.Models;

namespace ERDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SpainCustommer();
            //Query2();
            //CarlosName();
            //Breveges();

            OrderNumber();

            Console.ReadLine();
        }

        private static void OrderNumber()
        {
            var northwindentitities = new NorthWindContext();
            var custwithmorethan10orders = northwindentitities.
                                            Customers.Where(x => x.Orders.Count > 10).
                                            Select(x => new
                                            {
                                                custId = x.CustomerId,
                                                orders = x.Orders,
                                                contact = x.ContactName
                                            });
            Console.WriteLine("\n customers with more than 10 orders ");
            foreach (var cust in custwithmorethan10orders)
            {
                Console.WriteLine($"\nThe customer with id : {cust.custId} is having " +
                $"{cust.orders.Count} orders");
                Console.WriteLine("-----------------");
                foreach (var ord in cust.orders)
                {
                    Console.WriteLine($"{ord.OrderId} -- {ord.OrderDate}--{ord.CustomerId}----{cust.contact}");
                }
            }
        }

        private static void Breveges()
        {
            var northwindentitities = new NorthWindContext();
            var productsincateggory = northwindentitities.Products.
            Where(x => x.Category.CategoryName == "Beverages" || x.Category.CategoryName == "Seafood").
            Select(x => new
            {
                products = x.ProductName,
                cat = x.Category.CategoryName
            });

            Console.WriteLine("\nThe items in Beverages category");
            foreach (var prod in productsincateggory)
            {
                Console.WriteLine($"{prod.products}---{prod.cat}");
            }
        }

        private static void CarlosName()
        {
            var northwindentitities = new NorthWindContext();
            var carlosnames = northwindentitities.Customers.Where(x => x.ContactName.Contains("Carlos")).
            Select(x => new
            {
                conatctname = x.ContactName,
                companyname = x.CompanyName
            });
            Console.WriteLine("\n Name containing carlos");
            foreach (var calname in carlosnames)
            {
                Console.WriteLine($"{calname.conatctname} -- {calname.companyname}");
            }
        }

        private static void Query2()
        {
            var northwindidentities = new NorthWindContext();
            var catabbvr = northwindidentities.Categories.Select(x => new { name = x.CategoryName, abbr = x.CategoryName.Substring(0, 3).ToUpper() });
            foreach (var catwithabbr in catabbvr)
            {
                Console.WriteLine($"{catwithabbr.name}---{catwithabbr.abbr}");
            }
        }

        private static void SpainCustommer()
        {
            var northwindentities = new NorthWindContext();

            var customerforspain = northwindentities.Customers.Where(x => x.Country == "Spain").Select(x => new { x.CompanyName, x.Country });
            var customerfromspain = from customer in northwindentities.Customers where customer.Country == "Spain" select new { customer.CompanyName, customer.Country };

            foreach (var item in customerforspain)
            {
                Console.WriteLine($"{item.CompanyName}--{item.Country}");
            }
            Console.WriteLine("---------------------");

            foreach (var item in customerfromspain)
            {
                Console.WriteLine($"{item.CompanyName}--{item.Country}");
            }
        }
    }
}
