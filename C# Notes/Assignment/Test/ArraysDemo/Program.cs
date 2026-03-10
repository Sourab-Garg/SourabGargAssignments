namespace ArraysDemo
{
    internal class Program
    {
    public static void printArr(int[] arr)
    {
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
        static void Main(string[] args)
        {
            int[] arr1 = new int[3] { 1, 2, 3 };

            printArr(arr1);

            int[] arr2 = new int[3];

            for(int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine($"Enter {i + 1} element: ");
                arr2[i] = Convert.ToInt32(Console.ReadLine());
            }

            printArr(arr2);

            int[,] arr3 = new int[2, 2] {
                {1, 2},

                {3, 4}
            };

            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    Console.Write(arr3[i, j] + " ");
                }
                Console.WriteLine();
            }

            int[][] arr4 = new int[3][];
            arr4[0] = new int[3] { 1, 2, 3 };
            arr4[1] = new int[2] { 4, 5 };
            arr4[2] = new int[1] { 6 };

            for(int i = 0; i < arr4.Length; i++)
            {
                for (int j = 0; j < arr4[i].Length; j++)
                {
                    Console.Write(arr4[i][j] + " ");
                }
                Console.WriteLine() ;
            }

            Console.ReadLine();
        }
    }
}
