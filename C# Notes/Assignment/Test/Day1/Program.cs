namespace Day1
{
    internal class Program
    {
        public static void Update(ref int x,ref object y)
        {
            x++;
            y = (int)y+1;
            
        }
        static void Main(string[] args)
        {
            int x;
            int y;

            Console.WriteLine($"Enter a and b: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());

            int z = x + y;
            Console.WriteLine($"Sum of {x} and {y} is: {z}");

            var a = "sourab";
            var b = 12;
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());

            dynamic c = "sourab";
            Console.WriteLine(c.GetType());
            c = 12;
            Console.WriteLine(c.GetType());

            int d = 12;
            object obj = d;
            Console.WriteLine(obj.GetType());

            Console.WriteLine($"Before d = {d} and obj = {obj}");
            Update(ref d, ref obj);
            Console.WriteLine($"Before d = {d} and obj = {obj}");

            Console.ReadLine();
        }
    }
}
