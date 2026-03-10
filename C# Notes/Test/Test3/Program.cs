using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test3
{
    public class WordFrequencyAnalyzer
    {
        public static Dictionary<string, int> CountWordFrequencies(List<string> lines)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            foreach(string line in lines)
            {
                var newLine = Regex.Matches(line.ToLower(), "[a-z]+");
                foreach(Match regexResult in newLine)
                {
                    string word = regexResult.Value;
                    if (res.ContainsKey(word))
                    {
                        res[word]++;
                    }
                    else
                    {
                        res[word] = 1;
                    }
                }
            }
            return res;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> lines = new List<string>
            {
                "C# is great. C# is powerful!",
                "Generics and dictionaries are very useful.",
                "Dictionaries help us count frequencies.",
                "c# developers often use LINQ with dictionaries.",
                "Is C# case-sensitive? Yes, but our word counter is not."
            };

            Console.WriteLine("=== Word Frequency Analyzer ===\n");

            Dictionary<string, int> frequencies = WordFrequencyAnalyzer.CountWordFrequencies(lines);

            Console.WriteLine($"Total distinct words: {frequencies.Count}\n");

            int topN = 3;

            var topWords = frequencies.OrderByDescending(x=> x.Value).ThenBy(x=>x.Key).Take(topN);

            Console.WriteLine($"Top {topN} most frequent words:");
            foreach (var kv in topWords)
            {
                Console.WriteLine($"  {kv.Key} : {kv.Value}");
            }

            Console.WriteLine("\nAll words (sorted alphabetically):");
            foreach (var kv in frequencies.OrderBy(kv => kv.Key))
            {
                Console.WriteLine($"  {kv.Key} : {kv.Value}");
            }
        }
    }
}
