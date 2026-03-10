namespace ThreadJoinDemo2
{
    internal class Program
    {
        static void P()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("-");
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(P);
            Console.Write("Start");
            t.Start();
            t.Join();
            Console.Write("End");
            
            Console.ReadLine();
        }
    }
}
