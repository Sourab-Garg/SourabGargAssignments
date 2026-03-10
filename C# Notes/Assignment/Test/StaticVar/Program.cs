namespace StaticVar
{
    internal class Program
    {
        class Counter
        {
            public static int count = 0;
            public int countt = 0;
            public Counter()
            {
                count++;
                countt++;

            }
        }
        static void Main(string[] args)
        {
            Counter obj1 = new Counter();
            Counter obj2 = new Counter();

            Console.WriteLine(Counter.count);

            Console.WriteLine(obj1.countt +" "+ obj2.countt);
           

            Console.ReadLine();

        }
    }
}
