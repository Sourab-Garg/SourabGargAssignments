namespace ParamsDemo
{
    class Employee
    {
        //public void tSal(int sal, int bonus)
        //{
        //    Console.WriteLine($"Total Salary is : {sal + bonus}.");
        //}
        //public void tSal(int sal, int bonus, int allowances)
        //{
        //    Console.WriteLine($"Total Salary is : {sal + bonus + allowances}.");
        //}
        //public void tSal(int sal, int bonus, int allowances, int hrAllowances)
        //{
        //    Console.WriteLine($"Total Salary is : {sal + bonus + allowances+hrAllowances}.");
        //}

        public void tSal(params int[] sal)
        {
            int ts = 0;
            for (int i = 0; i < sal.Length; i++)
            {
                ts = ts + sal[i];
            }
            Console.WriteLine($"Total Salary is:{ts} ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.tSal(100,200);
            emp1.tSal(100, 200, 300);
            emp1.tSal(100, 200, 300, 400);

            Console.ReadLine();
        }
    }
}
