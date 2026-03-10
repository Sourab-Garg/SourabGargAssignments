namespace AnonyomousDeligate
{
    internal class Program
    {
        //public static void add(int x, int y)
        //{
        //    Console.WriteLine($"Sum is {x + y}");
        //}
        public static int sub(int x, int y)
        {
            return x - y;
        }

        public static int mul(int x, int y)
        {
            return x * y;
        }

        //public static void divide(int x, int y)
        //{
        //    Console.WriteLine($"Div is {x / y}");
        //}

        public delegate void delAdd(int x, int y);
        public delegate void delDiv(int x, int y);
        public delegate int del2(int x, int y);

        static void Main(string[] args)
        {
            //delAdd d1 = add;
            //d1(12, 21);

            delAdd m1 = delegate (int x, int y)
            {
                Console.WriteLine($"Sum is {x + y}");
            };

            delDiv m2 = delegate (int x, int y)
            {
                Console.WriteLine($"Div is {x / y}");
            };

            m1(12, 12);
            m2(12, 6);
            //m2.Invoke(12, 4);

            m2 += delegate (int x, int y)
            {
                Console.WriteLine($"Mul is: {x * y}");
            };

            m2(12, 2);

            Console.ReadLine();
        }
    }
}
