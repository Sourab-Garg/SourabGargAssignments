namespace Arrays
{
    internal class Program
    {
        public void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+ " ");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 23, 23, 1, 233};

            int[] arr2 = new int[3] { 1, 2, 3 };

            string[] names = new string[] { "abc", "def" };
            char[] chars = new char[3] { 'a', 'b', 'c', };

            int[] a = new int[5];
            int j, sum;

            Console.WriteLine("\nEnter values in array");

            for (int i = 0; i < a.Length; i++) {
                Console.Write($"Enter elemet {i+1}: ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            Program pp = new Program();
            pp.PrintArray(a);

            int add = 0 ;
            Console.WriteLine("\nFinding Sum: ");
            for (int i = 0; i < a.Length; i++)
            {
                add += a[i];
            }
            Console.WriteLine($"Sum is: {add}.");

            //For each loop (only for read)
            Console.Write("For each loop: ");
            foreach(int i in a)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\nModifying array via for loop: ");
            for(int i = 0; i < a.Length; i++)
            {
                a[i] *= 3;
            }
            Console.Write("After modification:");
            pp.PrintArray(a);

            int res = -1;
            int k;
            Console.Write("Enter element want to search: ");
            k = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == k){
                    res = i;
                    break;
                }
            }
            if(res == -1)
            {
                Console.WriteLine("Element not found");
            }
            else
            {
                Console.WriteLine($"Elelment {k} found at {res} index.");
            }

            Console.WriteLine("Bubble Sort: ");
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int jj = 0; jj < a.Length - i - 1; jj++)
                {
                    if (a[jj] > a[jj + 1])
                    {
                        int tempp = a[jj];
                        a[jj] = a[jj + 1];
                        a[jj + 1] = tempp;
                    }
                }
            }
            pp.PrintArray(a);
            Console.ReadLine();
        }
    }
}
