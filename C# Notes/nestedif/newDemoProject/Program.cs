
using System;
namespace nestedifdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Enter two co -ordinates :");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nThe point ({x},{y}) lies in ");
            if (x == 0)
                if (y == 0)
                    Console.WriteLine("Origin");
                else
                    Console.WriteLine("Y - axis");
            else
                if (y == 0)
                Console.WriteLine("X - axis");
            else
                if (x > 0)
                if (y > 0)
                    Console.WriteLine("1st Quadrant");
                else
                    Console.WriteLine("4th Quadrant");
            else
                        if (y > 0)
                Console.WriteLine("2nd Quadrant");
            else
                Console.WriteLine("3rd Quadrant");
            Console.ReadLine();
        }

    }
}
