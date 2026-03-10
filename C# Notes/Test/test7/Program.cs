namespace test7
{
    public class Employee
    {
        public double salary { get; set; }
        public virtual double CalculateBonus()
        {
            return salary * 0.10;
        }
    }

    public class Manager : Employee
    {   
        
        public override double CalculateBonus()
        {
            return salary * 0.20;
        }
    }

    public class Developer : Employee
    {
        public override double CalculateBonus()
        {
            return salary * 0.15;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Developer d = new Developer();
            d.salary = 2200.00;

            Manager m = new Manager();
            m.salary = 2200.00;

            Console.WriteLine(d.CalculateBonus());
            Console.WriteLine(m.CalculateBonus());

            Employee emp = new Manager();
            emp.salary = 2200.00;
            Console.WriteLine(emp is Manager);
            Console.WriteLine(emp.CalculateBonus());

            Console.ReadLine();
        }
    }
}
