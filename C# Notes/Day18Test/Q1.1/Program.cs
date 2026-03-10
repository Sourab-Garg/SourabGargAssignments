namespace Q1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "DL8NAB1234";
            Console.WriteLine(FindLongestIncreasingTrail(input));
        }

        static string FindLongestIncreasingTrail(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            int currStart = 0;
            int maxStart = 0;
            int maxLength = 1;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] < input[i + 1])
                {
                    int currLength = (i + 1) - currStart + 1;
                    if (currLength > maxLength)
                    {
                        maxLength = currLength;
                        maxStart = currStart;
                    }
                }
                else
                {
                    currStart = i+1;
                }
            }
            return input.Substring(maxStart, maxLength);

        }
    }
}
