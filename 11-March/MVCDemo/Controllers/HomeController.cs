using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string sampleDemo1()
        {
            return "Sye";
        }
        public string sampleDemo2(string name, int age)
        {
            return $"The name {name} and age: {age}";
        }
        public IActionResult sampleDemo3()
        {
            ViewBag.Name = "Sye";
            ViewBag.Age = 34;
            ViewData["Message"] = "Welcome to Asp.Net Core Learning";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }
        employee obj = new employee()
        {
            empId = 101,
            empName = "Sye",
            salary = 2323
        };
        List<employee> empList = new List<employee>()
        {
            new employee{ empId = 101, empName = "GGT", salary = 300434, imageurl = "/images/emp1.jpg"},
            new employee{ empId = 102, empName = "GGR", salary = 343234, imageurl = "/images/emp2.jpg"},
            new employee{ empId = 103, empName = "GGW", salary = 323434, imageurl = "/images/emp3.jpg"},
            new employee{ empId = 104, empName = "GGQ", salary = 342234, imageurl = "/images/emp4.jpg"}
        };
        public IActionResult collectionofobjectpassing()
        {
            return View(empList);
        }

        public IActionResult display()
        {
            return View();
        }

        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
