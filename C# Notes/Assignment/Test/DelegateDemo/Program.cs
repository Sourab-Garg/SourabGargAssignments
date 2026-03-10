using System.Reflection.Metadata.Ecma335;

namespace DelegateDemo
{
   
    internal class Program
    {
        public static void sum(int x, int y)
        {
            Console.WriteLine(x + y);
        }

        public delegate void DelSum(int x, int y);
        public delegate int DelSub(int x, int y);

        public static void add(int x, int y) => Console.WriteLine(x + y);
        public static int div(int x, int y) => x / y;
        public static bool checkEven(int x) => x % 2 == 0;
        static void Main(string[] args)
        {
            DelSum obj1 =  sum;

            obj1(12, 21);

            DelSub obj2 = ( x, y) => {  return x - y; };
            Console.WriteLine(obj2(12, 10));

            Action<int, int> myAdd = add;
            myAdd(12, 21);

            Func<int, int, int> mySub = div;
            Console.WriteLine(div(12, 3));

            Predicate<int> isEven = checkEven;

            int testNum = 10;
            if (isEven(testNum))
            {
                Console.WriteLine($"{testNum} is an Even number.");
            }

            Console.ReadLine();
        }
    }
}
