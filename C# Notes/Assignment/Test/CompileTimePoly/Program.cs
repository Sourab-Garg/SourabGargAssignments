namespace CompileTimePoly
{
    class Area
    {
        public Area(int a)
        {
            Console.WriteLine(a * a);
        }
        public Area(int a, int b)
        {
            Console.WriteLine(a * b);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Area obj1 = new Area(1,2);
            Area obj2 = new Area(2);

            Console.ReadLine();
        }
    }
}
