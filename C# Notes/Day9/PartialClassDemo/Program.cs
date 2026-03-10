namespace PartialClassDemo
{
    public partial class Employee
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }

        public Employee(int empid, string empname)
        {
            this.Empid = empid;
            this.EmpName = empname;
        }
    }

    public partial class Employee
    {
        public void DisplayEmployee()
        {
            Console.WriteLine($"{Empid}--{EmpName}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee empobj = new Employee(101, "kiran");
            empobj.DisplayEmployee();
            Console.ReadLine();
        }
    }
}
