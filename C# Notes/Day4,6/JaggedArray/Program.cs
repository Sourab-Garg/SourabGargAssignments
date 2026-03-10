namespace JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Row is already defined
            int[][] JaggedArray = new int[3][];
            //JaggedArray[0] = new int[2] { 12, 45 };
            //JaggedArray[1] = new int[3] { 12, 45, 23 };
            //JaggedArray[2] = new int[1] { 12 };

            Console.WriteLine("Take input: ");

            for(int i = 0; i < JaggedArray.Length; i++)
            {
                Console.WriteLine($"Enter column size of row {i}:");
                int size = Convert.ToInt32(Console.ReadLine());
                JaggedArray[i] = new int[size];
                //Console.WriteLine($"Enter {size} elements of row {i}");

                for(int j = 0; j < size; j++)
                {
                    Console.WriteLine($"Enter {i},{j} element");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    JaggedArray[i][j] = temp;
                }
                
            }

            Console.WriteLine("\nPrinting: ");

            for(int i = 0; i < JaggedArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}th row ({JaggedArray[i].Length}): ");
                for(int j =0;j<JaggedArray[i].Length;j++){
                    Console.WriteLine($" {JaggedArray[i][j]}");
                }

            }


            Console.ReadLine();
        }
    }
}
