namespace test8
{
    public static class UnitConverter{
        public static double UsdToInr = 90.2;
        
        public static void GetWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Currency Converter");
        }
        public static double ConvertToInr(double usd)
        {
            return usd * UsdToInr;
        } 

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitConverter.GetWelcomeMessage();
            double res = UnitConverter.ConvertToInr(10);
            Console.WriteLine(UnitConverter.UsdToInr);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
