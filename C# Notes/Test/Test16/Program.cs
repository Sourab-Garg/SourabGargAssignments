namespace Test16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 12;
            Object obj = a;
            Console.WriteLine(obj);
            Console.WriteLine(obj.GetType());
            int b = (int)obj;
            Console.WriteLine(b);
            Console.WriteLine(b.GetType());

            int[,] arr = new int[2, 2];
            arr[0,0] = 1;
            Console.WriteLine(arr[0, 0]);

            int[][] arr1 = new int[2][];
            arr1[0] = new int[2];
            arr1[1] = new int[3];
            arr1[0][0] = 12;

            Console.WriteLine(arr1[0][0]);

            int c = sum(ref a);
            Console.WriteLine(c);
            Console.WriteLine(a);
            string msg;
            hello(out msg);
            hello(out string msgs);
        }

        public static void hello(out string aa)
        {
            aa = "HELLO";
            Console.WriteLine(aa);
        }
        public static int sum(ref int a)
        {
            a = a + a;
            return a;
        }
    }
}
