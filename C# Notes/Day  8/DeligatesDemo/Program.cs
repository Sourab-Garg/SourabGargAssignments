namespace DeligatesDemo
{
    internal class Program
    {
        public static void add(int x, int y)
        {
            Console.WriteLine($"Sum is {x + y}");
        }
        public static int sub(int x, int y)
        {
            return x - y;
        }

        public static int mul(int x, int y)
        {
            return x * y;
        }

        public delegate void delAdd(int x, int y);
        public delegate int  del2(int x, int y);
        static void Main(string[] args)
        {
            delAdd d1 = add;
            d1(12, 21);

            del2 d2 = sub;
            Console.WriteLine($"Sub is: " + d2(12, 2));

            d2 += mul;
            //d2 = mul;
            Console.WriteLine($"Mul is: " + d2(12, 2));


            Console.ReadLine();
        }
    }
}
