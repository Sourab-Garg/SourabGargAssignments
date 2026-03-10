namespace Test5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "226";
            int res = NumDecodings(s);
            Console.WriteLine(res);
        }
        public static int NumDecodings(string s)
        {
            if (s == null || s[0] == '0') return 0;

            int prev1 = 1;
            int prev2 = 1;

            for(int i =1; i < s.Length; i++)
            {
                int current = 0;
                if (s[i] != '0')
                {
                    current += prev1;
                }
                int twodigits = int.Parse(s.Substring(i - 1, 2));
                if(twodigits >= 10 && twodigits <= 27)
                {
                    current += prev2;
                }

                prev2 = prev1;
                prev1 = current;
            }

            return prev1;
        }
    }
}
