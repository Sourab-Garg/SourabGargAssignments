namespace Test2
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public abstract double CalculateSalary();
        public virtual string GetEmployeeType()
        {
            return "Default";
        }
    }

    public class PermanentEmployee : Employee
    {
        public double BasicSalary { get; set;}
        public double Allowance { get; } = 1000;
        public PermanentEmployee(int Id, string Name, double basicSalary) : base(Id, Name) 
        {
            BasicSalary = basicSalary;
        }

        public override double CalculateSalary()
        {
            return BasicSalary + Allowance;
        }
        public override string GetEmployeeType()
        {
            return "Permanent";
        }
    }
    public class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public ContractEmployee(int Id, string Name, double hourlyRate, double hoursWorked): base(Id, Name)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public override double CalculateSalary()
        {
            return HoursWorked * HourlyRate;
        }
        public override string GetEmployeeType()
        {
            return "Contract";
        }
    }

    internal class Program
    {
        static double CalculateTotalPayroll(List<Employee> employees)
        {
            return employees.Sum(x=> x.CalculateSalary());
        }
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.CalculateSalary()).First();
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee> {
                new PermanentEmployee(1,"Ram",40000),
                new ContractEmployee(2, "Aman", 500,80),
                new PermanentEmployee(3, "Shyam", 50000),
                new ContractEmployee(4, "Riya", 600, 70)
                };

            Console.WriteLine(CalculateTotalPayroll(employees));    
            Console.WriteLine(GetHighestPaidEmployee(employees).Name);

            var grouped = employees.GroupBy(x => x.GetEmployeeType());

            foreach (var group in grouped)
            {
                Console.WriteLine($"--- {group.Key} Employees ---");
                foreach ( var item in group)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.ReadLine();
        }
    }
}
