using System.Text.RegularExpressions;

namespace Q3
{
    internal class Program
    {
        public static void Main()
        {
            string[] tests =
            {
            "DL89 AB 1234",
            "MH12 CD 5678",
            "KA01 AB 12345",
            "DL1A AB 1234",
            "dl89 ab 1234",
            "DL89AB1234",
            "DL@9 AB 1234"
        };

            foreach (var t in tests)
            {
                Console.WriteLine($"{t} -> {ValidateLicensePlate(t)}");
            }
        }
        public static string ValidateLicensePlate(string plate)
        {
            if (plate.Length != 12)
                return "INVALID - Wrong length";

            if (plate[4] != ' ' || plate[7] != ' ')
                return "INVALID - Missing spaces";

            string pattern = "^[a-zA-Z]{2}[0-9]{2} [a-zA-Z]{2} [0-9]{4}$";
            if (!Regex.IsMatch(plate, pattern))
                return "INVALID - Invalid format";

            return "VALID";
        }
    }
}
