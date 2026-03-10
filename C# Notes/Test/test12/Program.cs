using System.Text;
using System.Collections;

namespace test12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("hello ");
            sb.Append("word");
            Console.WriteLine(sb.ToString());

            string name = "programming";
            StringBuilder sb1 = new StringBuilder();
            foreach(char ch in name)
            {
                if (!sb1.ToString().Contains(ch))
                {
                    sb1.Append(ch);
                }
            }
            Console.WriteLine(sb1.ToString());
            int[] arr = { 1, 2, 3, 4 };
            StringBuilder sb2 = new StringBuilder();

            for(int i = 0; i < arr.Length; i++)
            {
                sb2.Append(arr[i]);
                if(i < arr.Length - 1)
                {
                    sb2.Append(", ");
                }
            }

            Hashtable ht = new Hashtable();
            string input = "banana";

            foreach(char ch in input)
            {
                if (!ht.ContainsKey(ch))
                {
                    ht.Add(ch, 1);
                }
                else
                {
                    ht[ch] = (int)ht[ch] + 1;
                }
            }
            foreach(DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key+ ": "+ item.Value);
            }

            Console.ReadLine();
        }
    }
}
