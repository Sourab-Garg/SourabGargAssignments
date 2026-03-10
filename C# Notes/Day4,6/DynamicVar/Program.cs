using System;

namespace DynamicVar
{
    public class Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack Quack");
        }
    }
    public class Person
    {
        public void quack()
        {
            Console.WriteLine("person imitating as quack");
        }
    }
    internal class Program
    {
        public void InTheForest(dynamic d)
        {
            d.quack();
        }
        //public void InTheForest(Person p)
        //{
        //    p.quack();
        //}
        static void Main(string[] args)
        {
            int x = 23;
            //x = "HELLO"; //Cant do this

            var kk = 45; //data type selected on runtime
            var name = "hello";
            var emps = new List<string>() { "1", "2", "3" };

            Console.WriteLine(x.GetType());
            Console.WriteLine(kk.GetType());
            Console.WriteLine(name.GetType());
            Console.WriteLine(emps.GetType());

            //kk = "ss"; cant do this as kk is set to int type

            dynamic a = 21; //change variable data type dynamicly
                            //according to assigend value
            Console.WriteLine(a.GetType());
            a = "hello";
            Console.WriteLine(a.GetType());

            Program obj = new Program();
            Duck d = new Duck();
            Person p = new Person();
            obj.InTheForest(d);
            obj.InTheForest(p);


            Console.ReadLine();
        }
    }
}
