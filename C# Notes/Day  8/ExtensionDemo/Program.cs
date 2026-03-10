namespace ExtensionDemo
{
    public static class Intx
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 43;
            bool res = num.IsEven();
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}