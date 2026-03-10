namespace IsAsDemo
{
    class Employee
    {
        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name; 
        }
    }

    class Manager : Employee
    {
        public Manager(string name): base(name)
        {

        }
        public void ApproveLeave()
        {
            Console.WriteLine($"{Name} approved leave request");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Ram");
            Employee emp2 = new Manager("Sham");

            if(emp1 is Manager)
            {
                Console.WriteLine("emp1 is a manager");
            }
            else
            {
                Console.WriteLine("emp1 is not a manger");
            }
            if (emp2 is Manager)
            {
                Console.WriteLine("emp2 is a manager");
            }
            else
            {
                Console.WriteLine("emp2 is not a manger");
            }

            Manager mgr1 = emp1 as Manager;//emp1 isnot a manager so mgr1 becomes null
            Manager mgr2 = emp2 as Manager;
            if (mgr1 != null)
            {
                mgr1.ApproveLeave();
            }
            else
            {
                Console.WriteLine("emp1 is not a manager, cannot approve leave");
            }
            if (mgr2 != null)
            {
                mgr2.ApproveLeave();
            }
            else
            {
                Console.WriteLine("emp2 is not a manager, cannot approve leave");
            }
            Console.ReadLine();
        }
    }
}
