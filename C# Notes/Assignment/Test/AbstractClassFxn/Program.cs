namespace AbstractClassFxn
{
    public abstract class Machine
    {
        int x = 10;
        public Machine()
        {
            Console.WriteLine("Machine is starting "+ x);
        }
        public void rum()
        {
            Console.WriteLine("Running machine");
        }
        public abstract void Task();

    }

    public class Printer : Machine
    {
        public Printer()
        {
            Console.WriteLine("Printer starting ");
        }
        public override void Task()
        {
            Console.WriteLine("Printing paper");
        }

        public void rum()
        {
            base.rum();
            Console.WriteLine("printer running");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Printer printer = new Printer();
         
            printer.Task();
            printer.rum();


            Console.ReadLine();
        }
    }
}
