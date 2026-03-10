namespace LazyLINQDemp
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{Id = 1, Name = "Raghu", HireDate = new DateTime(2002,03,13)},
                new Employee{Id = 2, Name = "Ram", HireDate = new DateTime(2000,03,13)},
                new Employee{Id = 3, Name = "Sham", HireDate = new DateTime(1999,03,13)},
            };

            IEnumerable<Employee> query =
                employees
                    .Where(x => x.HireDate.Year >= 2000)
                    .OrderByDescending(x => x.Name);

            employees.Add(new Employee
            {
                Id = 4,
                Name = "Linda",
                HireDate = new DateTime(2003, 3, 5)
            });

            foreach (Employee e in query)
            {
                Console.WriteLine(e.Name);
            }
        }
    }
}
