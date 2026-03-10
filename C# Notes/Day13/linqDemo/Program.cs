namespace linqDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1= new int[] { 1, 2, 3, 4, 44, 21,4,5545 };
            string[] names = new string[] { "aa", "bb", "cc", "abc", "ABC", "123", "bob" };

            var numGT20 = from num in arr1 where num>20 select num;
            Console.WriteLine(numGT20.GetType());
            foreach(int el in numGT20)
            {
                Console.WriteLine(el);
            }

            var numGT19 = arr1.Where(x => x > 19);
            Console.WriteLine(numGT19.GetType());
            foreach(int el in numGT19)
            {
                Console.WriteLine(el);
            }

            var evenNum1 = from num in arr1 where num%2 == 0 select num;
            Console.WriteLine(evenNum1.GetType());
            foreach (int el in evenNum1)
            {
                Console.WriteLine(el);
            }

            var evenNum2 = arr1.Where(x => x %2 == 0);
            Console.WriteLine(evenNum2.GetType());
            foreach (int el in evenNum2)
            {
                Console.WriteLine(el);
            }

            var sumofArr1 = (from num in arr1 select num).Sum();
            Console.WriteLine(sumofArr1.GetType());
            Console.WriteLine(sumofArr1);

            var sumofarray2 = arr1.Sum();
            Console.WriteLine($"The sum is {sumofArr1}---{sumofarray2}");
            
            var aNames = from aName in names where aName.StartsWith("a") select aName;
            Console.WriteLine(aNames.GetType());
            foreach(string aName in aNames)
            {
                Console.WriteLine(aName); 
            }

            var bNames = names.Where(bName =>  bName.StartsWith("b"));
            Console.WriteLine(bNames.GetType());
            foreach (string bName in bNames)
            {
                Console.WriteLine(bName.Length);
            }

            string input = Console.ReadLine();
            var vowels = input.Where(x=> "aeiou".Contains(x) ||  "AEIOU".Contains(x));
            Console.WriteLine(vowels.Count());

            Console.ReadLine();
        }
    }
}
