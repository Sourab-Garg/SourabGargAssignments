namespace Vowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("Enter string:");
            string input = Console.ReadLine();
            string vowels = "aeiou";

            foreach(char ch in input)
            {
                if (vowels.Contains(ch)){
                    count++;
                }
            }
            Console.WriteLine($"Number of vowels are: {count}.");

            Console.ReadLine();
        }
    }
}
