namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            string[] array = {
            "1000000001",
            "1000000002",
            "1000000003",
            "1000000004",
            "1000000005"
        };

            Console.WriteLine(CalculateSum(N, array));
        }
        public static long CalculateSum(int N, string[] array)
        {
            long sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += long.Parse(array[i]);
            }

            return sum;
        }
    }
}
