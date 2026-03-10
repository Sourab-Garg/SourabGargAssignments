namespace TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = "abc";
            string input = "2.2";

            if (float.TryParse(input, out float result))
            {
                Console.WriteLine($"Success: {result}");
            }
            else
            {
                Console.WriteLine("Conversion failed. Please enter a valid number.");
            }

            string input1 = "500";
            int result1 = int.Parse(input1);
            Console.WriteLine(result1.GetType());

            Console.ReadLine();
        }
    }
}
