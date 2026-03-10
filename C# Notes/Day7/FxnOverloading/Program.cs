namespace FxnOverloading
{
    class abcd
    {
        public void add(int x, int y)
        {
            Console.WriteLine($"The sum of two integers is {x + y}");
        }
        //not an overloaded methd
        //public int add(int y, int x)
        //{
        //    return (x + y);
        //}
        public double add(int k, decimal ss, double jj)
        {
            return (k + Convert.ToDouble(ss) + jj);
        }

        public decimal add(float k, decimal ss, double jj)
        {
            return (Convert.ToDecimal(k) + ss + Convert.ToDecimal(jj));
        }

    }
    class cde : abcd
    {
        public void add(int x, char ch)
        {
            Console.WriteLine($"The sum is {x + ch}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            cde obj = new cde();
            obj.add(80, 'A');
            obj.add(12, 45);
            Console.WriteLine($"{obj.add(123.45F, 345.678M, 8992.899)}");

            Console.WriteLine($"{obj.add(12, 456.67M, 789.345)}");
            Console.ReadLine();
        }


    }
}