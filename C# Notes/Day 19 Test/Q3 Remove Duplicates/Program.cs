namespace Q3_Remove_Duplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            string numStr = Convert.ToString(num);
            string result = "";
            for (int i = 0; i < numStr.Length; i++)
            {
                if (result.Contains(numStr[i]))
                {
                    continue;
                }
                result += numStr[i];
            }
            int resultInt = int.Parse(result);
            Console.WriteLine(resultInt);
            Console.ReadLine();
        }
    }
}
