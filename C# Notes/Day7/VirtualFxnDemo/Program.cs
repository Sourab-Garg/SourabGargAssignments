using VirtualFxnDemo;

namespace VirtualFxnDemo
{
    class BaseClass
    {
        public virtual void display()
        {
            Console.WriteLine("Base class fxn");
        }
    }
    class SubClass: BaseClass
    {
        public override void display()
        {
            Console.WriteLine("Child class fxn");
        }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {
        BaseClass objb = new BaseClass();
        BaseClass objs = new SubClass();
        objb.display();
        objs.display();

        Console.ReadLine();
        }
    }

