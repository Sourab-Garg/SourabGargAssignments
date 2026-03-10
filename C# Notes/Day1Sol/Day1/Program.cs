namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ifDemo1();
            ifDemo2();

            Console.ReadLine();

        }

        private static void ifDemo2()
        {
            int a, b, c, d;
            Console.WriteLine("Enter 4 digits");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine());

            if ((a > b) && (a > c) && (a > d))
                Console.WriteLine($"A is greather which is {a}");
            else if ((b > c) && (b > d))
                Console.WriteLine($"B is greater which is {b}");
            else if (c > d)
                Console.WriteLine($"C is greater which is {c}");
            else
                Console.WriteLine($"D is greater which is {d}");
        }

        private static void ifDemo1()
        {
            int a, b, c, d, l;
            Console.WriteLine("Enter 4 digits");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine());

            l = a;
            if (b > l)
                l = b;
            if (c > l)
                l = c;
            if (d > l)
                l = d;
            Console.WriteLine($"The largest number is {l}.");
        }
    }
}
