namespace ThreadingDemo
{
    internal class Program
    {

        public static void Func1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Func 1 write {i}");
            }
        }
        public static void Func2()
        {
            for (int i = 6; i > 0; i--)
            {
                Console.WriteLine($"Func 2 write {i}");
            }
        }
        public static void Func3()
        {
            for (int i = 16; i > 10; i--)
            {
                Console.WriteLine($"Func 3 write {i}");
            }
        }

        static void Main(string[] args)
        {
            ThreadStart t1 = new ThreadStart(Func1);
            ThreadStart t2 = new ThreadStart(Func2);
            Thread first = new Thread(t1);
            Thread second = new Thread(t2);
            Thread third = new Thread(Func3);
            first.Priority = ThreadPriority.Lowest;
            second.Priority = ThreadPriority.Highest;
            first.Start();
            third.Start();
            second.Start();
            Func1();
            Func2();
            Console.ReadLine();
        }
    }
}


