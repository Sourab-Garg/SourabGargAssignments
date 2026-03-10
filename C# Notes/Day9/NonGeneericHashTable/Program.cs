using System.Collections;

namespace NonGeneericHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "Hello");
            ht.Add('a', 12.2);
            ht.Add("ram", DateTime.Now);

            Console.WriteLine(ht[1]);
            Console.WriteLine(ht['a']);
            Console.WriteLine(ht["ram"]);

            foreach (DictionaryEntry el in ht) { 
                Console.WriteLine($"Key: {el.Key} and Value: {el.Value}");
            }

            SortedList s1 = new SortedList() { {100, "Sham"}, {109, "Ram"} };

            s1.Add(101, "Alice");
            s1.Add(102, "Bob");
            s1.Add(105, "Charlie");
            s1.Add(104, "david");
            s1.Add(103, "kiran");

            foreach (DictionaryEntry el in s1) {

                Console.WriteLine($"Key: {el.Key} and Value: {el.Value}");
            }

            Console.ReadLine();
        }

    }
}
