using ClassLibrary2;

namespace AccessModifier
{
    public class abcd
    {
        private int a;
        public void seta(int k)
        {
            a = k;
        }
        public int geta()
        {
            return a;
        }
        public int b = 2;
        protected int c = 3;
    }
    internal class Program : Class1
    {
        static void Main(string[] args)
        {   
            //abcd abcdobj = new abcd();
            //Program pp = new Program();
            //Console.WriteLine($"{abcdobj.b}");
            //Console.WriteLine($"{pp.b}");
            //Console.WriteLine($"{pp.c}");
            //abcdobj.seta(1);
            //Console.WriteLine($"{abcdobj.geta()}");
            //Console.ReadLine();
            Class1 c1 = new Class1();
            Console.WriteLine($"{c1.D}");


        }
    }
}