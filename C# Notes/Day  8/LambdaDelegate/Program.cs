namespace LambdaDelegate
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
        public static void div(int x, int y)
        {
            Console.WriteLine($"Div is {x / y}");
        }

        public delegate void delAdd(int x, int y);
        public delegate int del2(int x, int y);
        static void Main(string[] args)
        {
            delAdd m1 = (x, y) => Console.WriteLine($"Sum is : {x + y}");
            del2 m2 = (x, y) => x - y;

            m1 += (x, y) => Console.WriteLine($"Div is: {x / y}");

            m1(12, 2);
            //m2.Invoke(12, 2);
            Console.WriteLine(m2.Invoke(12,2));

            Console.ReadLine();
        }
    }
}
