namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            int k = 3;
            int[] arr = new int[] { 1,2,3,4,5,6,7};
            int sum1 = 0;
            for(int i = 0; i < k; i++)
            {
                sum1 += arr[i];
            }
            Console.WriteLine(sum1);

            for(int i = 0; i < arr.Length-k; i++) 
            {
                sum1 -= arr[i];
                sum1 += arr[i+k];
                Console.WriteLine(sum1);
            }
            int sum2 = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum2 += arr[i];
                if(i >= k)
                {
                    sum2 -= arr[i-k];
                }
                if(i >= k - 1)
                {
                    Console.WriteLine(sum2);
                }
            }
            Console.ReadLine();
        }
    }
}
