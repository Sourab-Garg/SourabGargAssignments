using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class repo
    {
        public static List<cons> Retrive()
        {
            List<cons> list = new List<cons>() 
            {
                new cons { EmployeeID = 101, FirstName = "Sudha", LastName = "Rani", City = "Bangalore", Sal = 34000 },
                new cons { EmployeeID = 102, FirstName = "Madhu", LastName = "Sudhan", City = "Hyderabad", Sal = 30000 },
                new cons { EmployeeID = 103, FirstName = "Kiran", LastName = "Kumar", City = "Hyderabad", Sal = 35000 },
                new cons { EmployeeID = 104, FirstName = "Sita", LastName = "Rani", City = "Hyderabad", Sal = 25000 },
                new cons { EmployeeID = 105, FirstName = "Rakesh", LastName = "Sharma", City = "Bangalore", Sal = 19000 },
                new cons { EmployeeID = 106, FirstName = "Mahesh", LastName = "Babu", City = "Mysore", Sal = 36000 },
                new cons { EmployeeID = 107, FirstName = "Anil", LastName = "Verma", City = "Bangalore", Sal = 42000 },
                new cons { EmployeeID = 108, FirstName = "Sunita", LastName = "Kapoor", City = "Mysore", Sal = 28000 },
                new cons { EmployeeID = 109, FirstName = "Vijay", LastName = "Prasad", City = "London", Sal = 45000 },
                new cons { EmployeeID = 110, FirstName = "Amara", LastName = "Deep", City = "London", Sal = 41000 }
            };

            return list;
        }
    }
}
