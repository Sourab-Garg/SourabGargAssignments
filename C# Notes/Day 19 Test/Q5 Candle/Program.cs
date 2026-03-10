namespace Q5_Candle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            int[] candles = new int[age];
            for (int i = 0; i < age; i++)
            {
                Console.WriteLine($"Enter candle number {i + 1} out of {age}");
                int tempcandle = Convert.ToInt32(Console.ReadLine());
                if (tempcandle == 0 || tempcandle > age)
                {
                    Console.WriteLine("Invalid input! Enter again");
                    i--;
                    continue;
                }
                candles[i] = tempcandle;
            }

            int count = FindCount(candles);
            Console.WriteLine($"Tallest candle occur {count} times.");

            Console.ReadLine();
        }
        static int FindCount(int[] candles)
        {
            int max = int.MinValue;
            int count = 0;
            foreach (int i in candles)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            foreach (int i in candles)
            {
                if (i == max)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
