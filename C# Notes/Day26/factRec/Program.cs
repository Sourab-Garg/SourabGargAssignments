namespace factRec
{
    internal class Program
    {
        public static int findFact(int n)
        {
            if(n <= 1)
            {
                return 1;
            }
            return n * findFact(n - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int n = 5;
            int res = findFact(n);
            Console.WriteLine(res);
        }
    }
}
