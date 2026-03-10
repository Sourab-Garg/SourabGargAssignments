namespace Array2D
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;

            for (int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }

            //2D array
            int[,] a2 = new int[3, 3];

            //3D array
            int[,,] a3 = new int[3, 3, 3];

            Console.WriteLine("\n Enter 2d array element");
            for(int i = 0; i < a2.GetLength(0); i++)
            {
                for(int j = 0; j < a2.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter {i+1} and {j+1} element: ");
                    a2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    Console.Write(a2[i, j]+" ");
                }
                Console.WriteLine();   
            }

            Console.ReadLine();
        }
    }
}
