namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //switchDemo1();
            int a, b, c;
            char ch;
            Console.WriteLine("Enter a and b: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"a. Add");
            Console.WriteLine($"b. Sub");
            Console.WriteLine($"c. Mul");
            Console.WriteLine($"d. Div");

            Console.WriteLine("Emter operation: ");
            ch = Convert.ToChar(Console.ReadLine());

            switch (ch)
            {
                case 'a':
                case 'A':
                    c = a + b;
                    Console.WriteLine($"Sum is : {c}");
                    break;
                case 'b':
                case 'B':
                    c = (a > b) ? (a - b) : (b - a);
                    Console.WriteLine($"Sub is {c}");
                    break;
                case 'c' or 'C':
                    c = a * b;
                    Console.WriteLine($"Mul is {c}");
                    break;
                case 'd' or 'C':
                    c = a / b;
                    Console.WriteLine($"Div is {c}");
                    break;
                default:
                    Console.WriteLine("Invlaid Input");
                    break;
            }


            Console.WriteLine();
        }

        private static void switchDemo1()
        {
            int a, b, c, choice;
            Console.WriteLine("Enter a and b: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"1. Add");
            Console.WriteLine($"2. Sub");
            Console.WriteLine($"3. Mul");
            Console.WriteLine($"4. Div");

            Console.WriteLine("Emter operation: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    c = a + b;
                    Console.WriteLine($"Sum is : {c}");
                    break;
                case 2:
                    c = (a > b) ? (a - b) : (b - a);
                    Console.WriteLine($"Sub is {c}");
                    break;
                case 3:
                    c = a * b;
                    Console.WriteLine($"Mul is {c}");
                    break;
                case 4:
                    c = a / b;
                    Console.WriteLine($"Div is {c}");
                    break;
                default:
                    Console.WriteLine("Invlaid Input");
                    break;
            }
        }
    }
}
