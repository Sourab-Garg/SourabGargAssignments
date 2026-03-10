namespace InbuiltDelegate
{
    internal class Program
    {
        public static void add(int a, float b, decimal k)
        {
            Console.WriteLine($"The sum is:{a + Convert.ToDecimal(b) + k}");
        }

        public static double add(int a, decimal b, double kk)
        {
            return (a + Convert.ToDouble(b) + kk);

        }

        public static bool checklength(string str)
        {
            if (str.Length > 10)
                return true;
            else
                return false;
        }
        //public delegate void mydelegate1(int a, float b, decimal k);
        //public delegate double mydelegate2(int a, decimal b, double kk);
        //public delegate bool mydelegate3(string str);
        static void Main(string[] args)
        {
            Action<int, float, decimal> m1 = add;
            m1(12, 56F, 456.67M);
            Func<int, decimal, double, double> m2 = add;
            double result = m2(12, 45.67M, 78.9);
            Console.WriteLine(result);
            Predicate<string> m3 = checklength;
            bool res = m3("HelloWorld!");
            Console.WriteLine($"The string length is having more than 10 chars:{res}");
            Console.ReadLine();
        }
    }
}