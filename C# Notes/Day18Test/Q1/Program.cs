namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "DL8NAB1234";
            Console.WriteLine(FindLongestIncreasingTrail(input));
        }
        public static string FindLongestIncreasingTrail(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            int start = 0;
            int maxStart = 0;
            int maxLength = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                {
                    int currentLength = i - start + 1;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxStart = start;
                    }
                }
                else
                {
                    start = i;
                }
            }

            return input.Substring(maxStart, maxLength);
        }
    }
}

