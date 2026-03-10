namespace RemoveDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2) Take an integer array which contains duplicate values and remove the duplicate 
            //elements from the array and show me the result in new array or in the same arrray ?

            int n;

            Console.WriteLine("Enter size of array: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];
            int[] result = new int[n];
            int count = 0;

            Console.WriteLine($"Enter {n} elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine()); //Take input from user
            }

            for (int i = 0; i < n; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isDuplicate = true;
                        break; // If duplicate is found break inner loop
                    }
                }

                if (!isDuplicate)
                {
                    result[count] = arr[i]; // If duplicate not found then add element to result array
                    count++;
                }
            }

            Console.WriteLine("\nArray after removing duplicates:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(result[i] + " ");
            }

            Console.ReadLine();
        }
    }
}