using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Mail is: john.doe@gmail.com";
            string pattern1 = @"\b[a-zA-Z0-9][a-zA-Z0-9._]*[a-zA-Z0-9]@([a-zA-Z0-9]+\.)+[a-z]{2,6}\b";
            if (Regex.IsMatch(s1, pattern1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            string s2 = "Date is: 2024-12-31";
            string s3 = "2024/12/31";
            string s4 = "Date is: 21-10-2024";
            string s5 = "21/10/2024";

            string pattern2 = @"\b(19[0-9][0-9]|20[0-9][0-9])[/-](0[0-9]|1[0-2])[/-](0[0-9]|[12][0-9]|3[01])\b";
            string pattern3 = @"\b(0[0-9]|[12][0-9]|3[01])[/-](0[0-9]|1[0-2])[/-](19\d{2}|20\d{2})\b";
            if (Regex.IsMatch(s2, pattern2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            if (Regex.IsMatch(s4, pattern3))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            string s6 = "1234 - 5678 - 9012 - 3456";
            string s7 = "1234 5678 9012 3456";
            string s8 = "1234567890123456";
            string s9 = "1234 -- 5678 - 9012 - 3456"; 
            //s9 is false

            string pattern4 = @"\b\d{4}(?: - |[ -])?\d{4}(?: - |[ -])?\d{4}(?: - |[ -])?\d{4}\b";
            string pattern5 = @"\b\d{4}((-)?|( )?|( - )?)?\d{4}((-)?|( )?|( - )?)?\d{4}((-)?|( )?|( - )?)?\d{4}\b";

            if (Regex.IsMatch(s8, pattern4))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
