namespace jumpStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sumdoWhile();
            //goTO();

            Console.ReadLine();
        }

        private static void goTO()
        {
            int num;
        L1:
            Console.WriteLine("Enter num: ");
            num = Convert.ToInt32(Console.ReadLine());

            if (num == 69)
            {
                Console.WriteLine("Done");
            }
            else
            {
                goto L1;
            }
        }

        private static void sumdoWhile()
        {
            int sum = 0;
            int num;

            do
            {
                Console.WriteLine("Enter the number");
                num = Convert.ToInt32(Console.ReadLine());
                if (num == 0)
                {
                    Console.WriteLine($"Final sum is: {sum}");
                    break;
                }
                if (num < 0)
                {
                    Console.WriteLine($"Cant add -ve numbers");
                    continue;
                }
                else
                {
                    sum = sum + num;
                    Console.WriteLine($"Sum is: {sum}");
                }

            }
            while (true);
        }
    }
}
