namespace LocalFunctionsDemo
{
    internal class Program
    {
        public int CaluclateSomething(int a, int b)
        {
            //int sum = a + b;
            //int difference = a - b;
            return Sum(a,b) * Difference(a,b);

            int Sum(int x, int y)
            {
                return x + y;
            }
            int Difference(int x, int y)
            {
                return x - y;
            }
        }
        static void Main(string[] args)
        {
            Program pp = new Program();
            Console.WriteLine($"Result :{pp.CaluclateSomething(6, 4)}");
            Console.ReadLine();
        }
    }
}