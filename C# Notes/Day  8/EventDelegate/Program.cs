namespace EventDelegate
{
    internal class Program
    {
       public Program()
        {
            myevent = new mydelegate1(testfunction);
        }
        public void testfunction()
        {
            Console.WriteLine("Test function called");
        }
        public delegate void mydelegate1();
        public event mydelegate1 myevent;
        static void Main(string[] args)
        {
            Program pp = new Program();
            pp.myevent();
            //above two lines can be wtiteen in a single line like tis 
            new Program().myevent();
            Console.ReadLine();
        }
    }
}