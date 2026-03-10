namespace GenericsDemo
{

    internal class Program
    {
        //public static void swap(ref int x, ref int y)
        //{
        //    int temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}

        //public static void swap(ref DateTime x, ref DateTime y)
        //{
        //    DateTime temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}
        //public static void swap(ref string x, ref string y)
        //{
        //    string temp;
        //    temp = x;
        //    x = y;
        //    y = temp;
        //}

        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now.AddDays(2);

            Console.WriteLine($"Before swapping: ");
            Console.WriteLine($"Date1: {date1} Date2: {date2}");
            //swap(ref date1, ref date2);
            Helper1.swap(ref date1, ref date2);
            Console.WriteLine($"After swapping: ");
            Console.WriteLine($"Date1: {date1} Date2: {date2}");

            int x = 12;
            float a = 12.2f;
            float b = 12.2f;

            Console.WriteLine($"Sum is: {Helper1.add1(a, b)}");
            Console.WriteLine($"Sum is: {Helper1.add2(x, b)}");

            int n = 21;
            int m = 12;

            Console.WriteLine($"Before swapping: ");
            Console.WriteLine($"n: {n} m: {m}");

            Helper2<int>.swap(ref n, ref m);
            
            Console.WriteLine($"After swapping: ");
            Console.WriteLine($"n: {n} m: {m}");

            Console.ReadLine();
        }
    }
}
