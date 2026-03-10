using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var subject = Console.ReadLine();

            var regex = new Regex(pattern);
            var match = regex.Match(subject);

            while (match.Success)
            {
                Console.WriteLine($"{match.Success}--{match.Index}--{match.Length}.");
                match = match.NextMatch();
            }
            Console.ReadLine();
        }
    }
}
