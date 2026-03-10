using static System.Console;
using static UsingStaticClassDemo.MySelf;

namespace UsingStaticClassDemo
{
    static class MySelf
    {
        public static void WhoAmI()
        {
            WriteLine("C# 6.0 New Feature!");
        }
    }
    class UsingStatic
    {
        static void Main(string[] args)
        {
            //MySelf obj = new MySelf();
            WhoAmI();
            ReadLine();
        }
    }

}