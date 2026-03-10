namespace ThreadJoinDemo
{
    internal class Program
    {

        public static void Fun1()
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("Func1() writes {0}", i);
            }
        }

        public static void Fun2()
        {
            for (int j = 6; j > 0; j--)
            {
                Console.WriteLine("Func2() writes {0}", j);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start of the main program ");
            Thread firstthread = new Thread(new ThreadStart(Fun1));
            Thread secondthread = new Thread(new ThreadStart(Fun2));
            firstthread.Start();
            secondthread.Start();

            firstthread.Join();
            secondthread.Join();
            Console.WriteLine("End of main()");
        }
    }
}