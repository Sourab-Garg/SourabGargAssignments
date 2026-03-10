namespace StaticFxn
{

     sealed public class Temp
    {
        public static void sum(int x, int y)
        {
            Console.WriteLine($"Sum is: {x + y}");
        }

        public void sub(int x, int y)
        {
            Console.WriteLine($"Sub is: {x - y}");
        }
    }

    //public class Demo : Temp
    //{

    //}
    internal class Program
    {

        static void Main(string[] args)
        {
            Temp.sum(12, 12);
            Temp obj = new Temp();
            obj.sub(12, 2);

            Console.ReadLine();
        }
    }
}
