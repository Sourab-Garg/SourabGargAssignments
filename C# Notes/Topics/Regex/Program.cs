using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- 1. Basic Validation (Anchors and Quantifiers) ---
            List<string> usernames = new List<string> { "Ram_123", "User01", "1Ram", "ab", "User@123" };

            // Starts with letter, followed by 4-11 word chars including '_' (Total 5-12)
            string userPattern = @"^[a-zA-Z]\w{4,11}$";

            Console.WriteLine("--- Username Check ---");
            foreach (string s in usernames)
            {
                // Regex.IsMatch returns true/false
                Console.WriteLine($"{s}: {Regex.IsMatch(s, userPattern)}");
            }

            // --- 2. Extraction (Finding Multiple Values) ---
            string priceText = "Pen costs 10.50, Book costs 250.99, Pencil costs 5";

            // Matches digits, and optionally a dot with 1-2 more digits
            string pricePattern = @"\d+(\.\d{1,2})?";

            Console.WriteLine("\n--- Price Extraction ---");
            var matches = Regex.Matches(priceText, pricePattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Found Price: {match.Value}");
            }

            // --- 3. Advanced Date Validation (Logic & Ranges) ---
            string d5 = "12/25/2024"; // mm/dd/yyyy
            string d6 = "2020-15-09"; // yyyy-dd-mm

            // Strict MM/DD/YYYY: Month (01-12), Day (01-31), Year (1900-2099)
            // Note: We use ( | ) for OR logic and remove unnecessary [ ]
            string patternd1 = @"^(0[1-9]|1[0-2])[/-](0[1-9]|[12]\d|3[01])[/-](19|20)\d{2}$";

            // Strict YYYY-DD-MM: Year (1900-2099), Day (01-31), Month (01-12)
            string patternd2 = @"^(19|20)\d{2}[/-](0[1-9]|[12]\d|3[01])[/-](0[1-9]|1[0-2])$";

            Console.WriteLine("\n--- Date Validation ---");
            Console.WriteLine($"d5 (mm/dd/yyyy) Match: {Regex.IsMatch(d5, patternd1)}");
            Console.WriteLine($"d6 (yyyy-dd-mm) Match: {Regex.IsMatch(d6, patternd2)}");

            // B. Replace (Cleaning data)
            string messyPhone = "(987) 654-3210";
            string cleanPhone1 = Regex.Replace(messyPhone, @"[^\d]", ""); // Replace everything that is NOT a digit
            string cleanPhone2 = Regex.Replace(messyPhone, @"[\D]", ""); // Replace everything that is NOT a digit
            Console.WriteLine($"\nCleaned Phone: {cleanPhone2}");
        }
    }
}