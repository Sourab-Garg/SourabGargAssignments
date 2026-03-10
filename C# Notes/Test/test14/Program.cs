namespace test14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {1,2,3,4,5 };
            int n = arr.Count();
            TakeInput:
                try
                {
                        Console.WriteLine("Enter elemnt to print");
                        int i = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Element at index {i} is: {arr[i]}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Enter index between 0 and {n - 1}");
                    goto TakeInput;
                } 

                Console.ReadLine();
        }
    }
}
