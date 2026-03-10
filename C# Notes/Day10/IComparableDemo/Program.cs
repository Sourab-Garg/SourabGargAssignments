namespace IComparableDemo
{
    class Employee : IComparable
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, int id, decimal salary)
        {
            Name = name;
            Id = id;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {Id}, Salary: {Salary:C})";
        }

        public int CompareTo(object? obj)
        {
            //throw new NotImplementedException();
            Employee otheremployee = obj as Employee;
            decimal thissalary = this.Salary;
            decimal otherempsalary = otheremployee.Salary;
            if (thissalary < otherempsalary)
            {
                return -1;
            }
            else if (thissalary > otherempsalary)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 12, 67, 8, 2, 78, 43, 22, 90, 129 };
            // primitive data types 

            numbers.Sort();
            foreach (int i in numbers)
            {
                Console.Write($"{i}  ");
            }

            List<Employee> employees = new List<Employee>()
            {
                new Employee("Jane", 102, 75000m),
                new Employee("John", 101, 90000m),
                new Employee("Mike", 103, 65000m)
            };

            employees.Sort();
            Console.WriteLine("\n");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }


            Console.ReadLine();
        }
    }
}
