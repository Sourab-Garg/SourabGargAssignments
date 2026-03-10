namespace LinqPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 12, 33, 44, 55, 6, 78, 100, 289, 25, 90, 44, 12, 78, 55, 100 };
            string[] names = new string[] { "Ravi", "Kiran", "Kishore", "Kavitha", "Mahesh", "Priya", "Suresh", "Anita", "Deepak", "Lakshmi", "Rajesh", "Pooja" };

            Dictionary<int, int> dict = numbers.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            foreach (var item in dict)
            {
                Console.Write(item.Key+"--"+item.Value+" ");
            }
            Console.WriteLine();

            List<int> list = numbers.Where(x=>x > 30).ToList();
            foreach(var item in list)
            {
                Console.Write(item+ " ");
            }
            Console.WriteLine();

            List<int> list1 = numbers.Where(x=> x%2==0).ToList();
            foreach (var item in list1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            double sum = numbers.Sum(x=> x);
            Console.WriteLine(sum);

            List<int> list2 = numbers.OrderByDescending(x=>x).Take(3).ToList();
            foreach (var item in list2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            double top = numbers.OrderByDescending(x => x).FirstOrDefault();
            Console.WriteLine(top);

            Dictionary<int, List<string>> dict1 = names.GroupBy(x => x.Length).ToDictionary(x=> x.Key, x=>x.ToList());
            foreach (var item in dict1)
            {
                Console.WriteLine(item.Key);
                foreach(var l in item.Value)
                {
                    Console.Write(l+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var evenOddGroup = numbers.GroupBy(x => x % 2 == 0 ? "Even" : "Odd");
            foreach (var item in evenOddGroup)
            {
                Console.WriteLine(item.Key);
                foreach(var i in item)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            var squaredSortedRange = numbers.Where(x => x > 30 && x < 100).OrderBy(x => x).Select(x => x * x);
            foreach (var item in squaredSortedRange)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List<string> filteredName = names.Where(x=> x.Length > 5).Select(x=> x.ToUpper()).ToList();
            foreach (var item in filteredName)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List<string> vowelEndSorted = names.Where(x => "aeiouAEIOU".Contains(x[x.Length - 1])).OrderBy(x => x.Length).ToList();
            foreach (var item in vowelEndSorted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var GroupedByLength = names.GroupBy(x => x.Length).OrderBy(x => x.Key);
            var smallestNames = GroupedByLength.FirstOrDefault();
            var largestNames = GroupedByLength.LastOrDefault();

            Console.WriteLine("---------------");
            foreach(var item in smallestNames)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in largestNames)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List<string> reversedNames = names.Select(x => new string(x.Reverse().ToArray())).ToList();
            List<string> reversedNames1 = names.Select(x => new string(x.ToArray().Reverse().ToArray())).ToList();

            foreach (var item in reversedNames)
            {
                Console.Write(item + " ");
            }   
            Console.WriteLine();

            string namefilter = names.Where(x => x.Equals("anita", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            Console.WriteLine(namefilter);

            Console.ReadLine();
        }
    }
}
