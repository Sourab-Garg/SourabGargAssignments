namespace BoxingUnboxingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 19;
            int y = x;

            x += 10;
            y += 10;

            Console.WriteLine(x);
            Console.WriteLine(y);

            Object z = x;
            Object a = z;
            z = (int)z + 10;

            Console.WriteLine(z);
            Console.WriteLine(a);

            Console.ReadLine();
        }
    }
}
