namespace forLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numer for finding factorial:");
            int num = Convert.ToInt32(Console.ReadLine());
            float f = 1.0f;
            
            for(int i = 1; i <= num; i++)
            {
                f = f * i;

            }

            Console.WriteLine($"Factorial of {num} is {f}");
            Console.ReadLine();

        }
    }
}
