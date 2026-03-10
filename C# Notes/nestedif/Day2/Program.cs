namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //doWhile();
            //whileDemo();
            //doWhile2();

            denomination();

            Console.ReadLine();
        }

        private static void denomination()
        {
            int amt = 487;
            int ten = 0;
            int five = 0;
            int one = 0;

            while (amt >= 10)
            {
                amt = amt - 10;
                ten++;
            }
            while (amt >= 5)
            {
                amt = amt - 5;
                five++;
            }
            while (amt >= 1)
            {
                amt = amt - 1;
                one++;
            }

            Console.WriteLine($" 10 note are: {ten}, 5 note are: {five}, 1 note are: {one}");
        }

        private static void doWhile2()
        {
            int counter = 1;
            bool keepGoing = true;
            do
            {
                Console.WriteLine($"{counter} ");
                if (counter % 100 == 0)
                {
                    Console.WriteLine("Do you want to continue (y or n):");
                    if (Console.ReadLine() == "n")
                    {
                        keepGoing = false;
                        break;
                    }
                }
                counter++;
            }
            while (keepGoing);
        }

        private static void whileDemo()
        {
            int count = 1;

            while (count <= 10)
            {
                Console.WriteLine($"{count} ");
                count++;
            }
        }

        private static void doWhile()
        {
            int counter = 11;

            do
            {
                Console.WriteLine($"{counter} ");
                counter++;
            }
            while (counter <= 10);
        }
    }
}
