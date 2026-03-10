namespace DelegateDemo1
{
    internal class Program
    {
        public static void Greeting(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
        public static int Addition(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b; 
        }
        public static int Calculate(int a, int b, Operation op)
        {
            return op(a, b);
        }
        public static bool IsEven(int a)
        {
            return a % 2 == 0; 
        }
        public static void Message(string name)
        {
            Console.WriteLine($"Good Morning {name}");
        }

        public static int CalculateAn(int a, int b, Func<int, int, int> operation)
        {
            return operation(a, b);
        }

        public delegate int Sum(int a, int b);
        public delegate int Operation(int a, int b);
        public delegate void GreetingDelegate(string name);
        static void Main(string[] args)
        {
            Action<string> greet = Greeting;
            greet("Ram");
            greet("Sham");
           

            Func<int, int, int> add = Addition;
            int result = add(12, 12);
            Console.WriteLine($"Sum is {result}");

            Predicate<int> even = IsEven;
            int a = 2;
            Console.WriteLine($"{a} is a even number: {even(a)}");

            Sum adds = Addition;
            Console.WriteLine(adds(12, 19));

            Console.WriteLine(Calculate(12, 12, Subtraction));
            Console.WriteLine(Calculate(12,12, Addition));

            GreetingDelegate hello = Greeting;
            hello += Message;
            hello("Ram");

            Console.WriteLine(CalculateAn(12, 12, Subtraction));
            Console.WriteLine(CalculateAn(12, 12, Addition));

            Console.ReadLine();
        }
    }
}
