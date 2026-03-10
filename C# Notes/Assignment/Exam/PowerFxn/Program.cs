namespace PowerFxn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //write a program to find x to the power of y without using mathematical pow function ?

            int x;
            int y;
            int ans  = 0;

            Console.WriteLine("Enter number: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Enter power of {x}: ");
            y = Convert.ToInt32(Console.ReadLine());

            int temp = y;

            while (temp != 0)
            {
                ans = ans + (x * x); 
                temp--;
            }

            Console.WriteLine($"{x} to the power {y} is: {ans}");

            Console.ReadLine();
        }
    }
}
