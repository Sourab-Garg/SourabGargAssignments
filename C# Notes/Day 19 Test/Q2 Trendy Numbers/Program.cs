namespace Q2_Trendy_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num  = Convert.ToInt32(Console.ReadLine());
            if(num <= 999 && num >= 100)
            {
                int n = (num / 10) % 10;
                if (n % 3 == 0)
                {
                    Console.WriteLine("Trendy number");
                }
                else
                {
                    Console.WriteLine("Not a tendy numer");
                }
            }
            else
            {
                Console.WriteLine("Not a trendy number");
            }
                Console.ReadLine();
        }
    }
}
