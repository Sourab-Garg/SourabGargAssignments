using System.Diagnostics;

namespace timeComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorting Algorithm Time Complexity Comparison\n");

            // Test with different array sizes
            int[] sizes = { 1000, 5000, 10000, 20000 };

            foreach (int size in sizes)
            {
                Console.WriteLine($"Array Size: {size}");
                Console.WriteLine(new string('-', 50));

                int[] originalArray = GenerateRandomArray(size);

                // Bubble Sort
                int[] array1 = (int[])originalArray.Clone();
                long bubbleTime = MeasureTime(() => BubbleSort(array1));
                Console.WriteLine($"Bubble Sort:     {bubbleTime,8} ms");

                // Selection Sort
                int[] array2 = (int[])originalArray.Clone();
                long selectionTime = MeasureTime(() => SelectionSort(array2));
                Console.WriteLine($"Selection Sort:  {selectionTime,8} ms");

                // Insertion Sort
                int[] array3 = (int[])originalArray.Clone();
                long insertionTime = MeasureTime(() => InsertionSort(array3));
                Console.WriteLine($"Insertion Sort:  {insertionTime,8} ms");

                Console.WriteLine();
            }
        }

        // Bubble Sort - O(n²)
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Selection Sort - O(n²)
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Swap
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        // Insertion Sort - O(n²)
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        // Helper method to measure execution time
        static long MeasureTime(Action sortAction)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sortAction();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // Generate random array
        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random(42); // Fixed seed for consistency
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10000);
            }
            return array;
        }
    }
}