namespace Q4_Only_Alphabets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = "";
            foreach(char ch in input)
            {
                if (char.IsLetter(ch))
                    {
                        if(result.Length > 0)
                        {
                            result += ",";
                        }
                        result += ch;
                    }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
