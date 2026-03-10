namespace StaticFunction
{
    class Abcd
    {
        static int a = 0;
        static public void count()
        {
            a = a + 1;
            Console.WriteLine($"The value is {a}");
        }
        static void Main(string[] args)
        {
            count();
            count();
            Console.ReadLine();
        }
    }
    internal class Program
    {
        
        
    }
}

