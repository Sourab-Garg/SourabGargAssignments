namespace StringFxn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello World";
            string str2 = "Hello";
            string str3 = "world";

            string sample = "";
            string sample2 = string.Empty;
            Console.WriteLine($"{sample}--{sample2}");
            //here chars denaotes index 
            Console.WriteLine($"chars means index value :{str[1]}");
            Console.WriteLine($"length : {str.Length}");


            // Modifying
            Console.WriteLine("\nModifying:");
            Console.WriteLine($"Insert: {str.Insert(7, "Beautiful")}");
            Console.WriteLine($"Remove: {str.Remove(7, 3)}");
            Console.WriteLine($"Replace: {str.Replace("World", "C#")}");
            Console.WriteLine($"Trim: '{str.Trim()}'");
            Console.WriteLine($"TrimStart: '{str.TrimStart()}'");
            Console.WriteLine($"TrimEnd: '{str.TrimEnd()}'");
            Console.WriteLine($"PadLeft: '{str2.PadLeft(10, '*')}'");
            Console.WriteLine($"PadRight: '{str2.PadRight(10, '-')}'");
            Console.WriteLine($"ToUpper: {str3.ToUpper()}");
            Console.WriteLine($"ToLower: {str2.ToLower()}");

            // Extracting
            Console.WriteLine("\nExtracting:");
            //Console.WriteLine($"Substring: {str.Substring(7, 3)}");
            Console.WriteLine($"Split: {string.Join(", ", str.Split(' '))}");

            // Formatting
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nFormatting:");
            double number = 12345.6789;
            Console.WriteLine($"Currency: {number.ToString("C")}");

            Console.WriteLine($"Exponential: {number.ToString("E")}");
            Console.WriteLine($"General: {number.ToString("G")}");
            Console.WriteLine($"Percentage: {number.ToString("P")}");
            DateTime date = DateTime.Now;
            Console.WriteLine($"Short Date: {date.ToString("d")}");
            Console.WriteLine($"Long Date: {date.ToString("D")}");
            Console.WriteLine($"Short Time: {date.ToString("t")}");
            Console.WriteLine($"Long Time: {date.ToString("T")}");

            // Searching
            Console.WriteLine("\nSearching:");
            Console.WriteLine($"StartsWith 'Hello': {str.StartsWith(" Hello")}");
            Console.WriteLine($"EndsWith '!': {str.EndsWith("!")}");
            Console.WriteLine($"IndexOf 'World': {str.IndexOf("World")}");
            Console.WriteLine($"Contains 'World': {str.Contains("World")}");


            Console.ReadLine();
        }
    }
}
