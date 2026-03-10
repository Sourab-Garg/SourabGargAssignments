namespace Q2
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public Employee(string name, double baseSalary) 
        {
            Name = name;
            BaseSalary = baseSalary;
        }
        public void PrintSalary()
        {
            Console.WriteLine($"{Name} is a {GetType().Name} with total Salary: {CalculateSalary()}");
        }
        public abstract double CalculateSalary();
    }
    public interface IBonus
    {
        double CalculateBonus();
    }
    public class FinanceEmployee: Employee, IBonus
    {
        public FinanceEmployee(string Name, double BaseSalary):base(Name, BaseSalary) { }
        public double CalculateBonus()
        {
            return BaseSalary * 0.20;
        }
        public override double CalculateSalary()
        {
            return CalculateBonus() + BaseSalary;
        }
    }
    public class MarketingEmployee: Employee, IBonus
    {
        public MarketingEmployee(string Name, double BaseSalary) : base(Name, BaseSalary) { }
        public double CalculateBonus()
        {
            return BaseSalary * 0.15;
        }
        public override double CalculateSalary()
        {
            return CalculateBonus() + BaseSalary;
        }
    }
    public class ITEmployee: Employee, IBonus
    {
        public ITEmployee(string Name, double BaseSalary) : base(Name, BaseSalary) { }
        public double CalculateBonus()
        {
            return BaseSalary * 0.25;
        }
        public override double CalculateSalary()
        {
            return CalculateBonus() + BaseSalary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>
            {
                new FinanceEmployee("Ravi", 50000),
                new MarketingEmployee("Ankit", 46000),
                new ITEmployee("Neha", 75000)
            };
            foreach (Employee emp in list)
            {
                emp.PrintSalary();
            }
            //Employee highestSalEmp = list.OrderByDescending(x => x.CalculateSalary()).FirstOrDefault();
            Employee highestSalEmp = list.MaxBy(x => x.CalculateSalary());
            Console.WriteLine(highestSalEmp.Name);
            list = list.OrderByDescending(x => x.CalculateSalary()).ToList();
            foreach (Employee emp in list)
            {
                emp.PrintSalary();
            }

            Console.ReadLine();
        }
    }
}
