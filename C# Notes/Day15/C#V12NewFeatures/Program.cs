using System;
using System.IO;

int a = 20;
int b = 30;
Console.WriteLine($"The sum is {a + b}");
hai.Demo obj = new hai.Demo();
obj.Method1(a);
Program2 obj2 = new Program2();
obj2.Method2();
Program2.Main();


class Program2
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
    }
    public void Method2()
    {
        Console.WriteLine("GG");
    }
}
namespace hai
{
    class Demo
    {
        public void Method1(int a)
        {
            Console.WriteLine($"{a}");

        }
    }
}