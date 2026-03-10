
namespace LinqToObejcts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 11, 22, 33, 44, 55 };
            var res1 = from num in arr1 where num > 15 select num;
            var res2 = arr1.Where(num => num < 15);

            foreach(int num in res1)
            {
                Console.WriteLine(num);
            }

            foreach(int num in res2)
            {
                Console.WriteLine(num); 
            }

            var employees1 = EmpRepository.Retrive();

            var employees2 = from emp in EmpRepository.Retrive() select emp;
            var employees3 = EmpRepository.Retrive().Select(x=>x);
            foreach (var employee in employees1)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }

            Console.WriteLine("\n\n");
            foreach (var employee in employees2)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }
            Console.WriteLine("\n\n");

            Console.WriteLine(employees1.GetType());
            Console.WriteLine(employees2.GetType());
            Console.WriteLine("\n\n");

            var usingOrderByThen = employees2.OrderBy(x => x.Sal).ThenBy(x => x.City);
            foreach (var employee in usingOrderByThen)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }

            Console.WriteLine("\n\n");

            var usingOrderByDescendingThen = employees2.OrderByDescending(x => x.Sal).ThenByDescending(x => x.City);
            foreach (var employee in usingOrderByDescendingThen)
            {
                Console.WriteLine($"{employee.EmployeeID}--{employee.FirstName}--{employee.LastName}--{employee.City}--{employee.Sal}");
            }

            var firstNameAndCity1 = from emp in employees2
                                   select new
                                   {
                                       emp.FirstName,
                                       emp.City
                                   };
            Console.WriteLine("\n\n");
            foreach(var emp in firstNameAndCity1)
            {
                Console.WriteLine(emp.FirstName + " " + emp.City);
            }

            var firstNameAndCity2 = from emp in employees2
                                    select new
                                    {
                                        fname = emp.FirstName,
                                        cname = emp.City
                                    };
            foreach (var emp in firstNameAndCity2)
            {
                Console.WriteLine(emp.fname + " " + emp.cname);
            }

            var firstNameAndCity3 = employees2.Select(x => new { x.FirstName, x.City });
            foreach (var emp in firstNameAndCity3)
            {
                Console.WriteLine(emp.FirstName + " " + emp.City);
            }

            Console.WriteLine("\n\n");

            var fullName1 = from emp in employees2
                                    select new
                                    {
                                        fname = emp.FirstName + " "+emp.LastName,
                                        cname = emp.City
                                    };
            foreach (var emp in fullName1)
            {
                Console.WriteLine(emp.fname + " " + emp.cname);
            }

            var fullName2 = employees2.Select(x => new { fname = x.FirstName + " " + x.LastName, x.City });
            
            foreach (var emp in fullName2)
            {
                Console.WriteLine(emp.fname + " " + emp.City);
            }

            Console.WriteLine("\n\n");

            var skipFew = employees1.Skip(2);
            var skipFewTakeFew = employees1.Skip(2).Take(2);

            var filterMadhu1 = from emp in employees1 where (emp.FirstName != "Madhu") select emp;
            var filterMadhu2 = employees1.Where(x => x.FirstName != "Madhu");

            var firstMadhu1 = (from emp in employees1 where (emp.FirstName == "Madhu") select emp).FirstOrDefault();
            //var firstMadhu2 = employees1.First(x => x.FirstName == "Madhu");
            var firstMadhu2 = employees1.FirstOrDefault(x => x.FirstName == "Madhu");
            if (firstMadhu1 == null){
                Console.WriteLine("Madhi not found");
            }
            foreach (var emp in skipFew)
            {
                Console.WriteLine(emp.FirstName + " " + emp.City);
            }

            Console.WriteLine("\n\n");

            var top3Sal = employees3.OrderByDescending(x => x.Sal).Take(3);
            foreach (var emp in top3Sal)
            {
                Console.WriteLine(emp.FirstName + " " + emp.City+ " "+ emp.Sal);
            }

            var groupByCity = employees3.OrderByDescending(x => x.Sal).GroupBy(x => x.City);
            foreach (var cityGroup in groupByCity)
            {
                Console.WriteLine($"City: {cityGroup.Key}");

                foreach(var emp in cityGroup) 
                { 
                Console.WriteLine(emp.FirstName + " " + emp.City + " " + emp.Sal);
                }
            }

            var groupbycity = employees1.GroupBy(x => x.City);

            foreach (var group in groupbycity)
            {
                Console.WriteLine($"\nThere are {group.Count()} employees in {group.Key}");
                Console.WriteLine("************************************************");
                Console.WriteLine($"{group.Key} total salary--{group.Sum(x => x.Sal)} where,");
                foreach (var emp in group)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.Sal}");
                }

            }


            Console.ReadLine();
        }
    }
}
