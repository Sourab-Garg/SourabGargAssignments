namespace DistanceConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Q)input consists of distance in mm.write a program to convert the distance in mm to metres,cm,mm?
            //eg: if total distance is 2715 ouput should be 2M,71cm,and 5mm
            //1 meter = 1000mm, 1cm = 10 mm

            Console.WriteLine("Enter Distance in mm: ");
            int x = Convert.ToInt32(Console.ReadLine());

            int meter = x / 1000;
            int cm = (x % 1000) / 10;
            int mm = x % 10;

            Console.Write("Result: ");

            if (meter > 0)
            {
                Console.Write($"{meter}M ");
            }

            if (cm > 0)
            {
                Console.Write($"{cm}cm ");
            }

            if (mm > 0)
            {
                Console.Write($"{mm}mm");
            }
            else if (meter == 0 && cm == 0 && mm == 0)
            {
                Console.Write("0mm");
            }

            Console.ReadLine();
        }
    }
}