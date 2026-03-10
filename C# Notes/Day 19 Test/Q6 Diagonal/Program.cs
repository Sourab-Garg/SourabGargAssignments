namespace Q6_Diagonal
{
        internal class Program
        {
            public static int diagonalDifference(List<List<int>> arr)
            {
                int primaryDiagonalSum = 0;
                int secondaryDiagonalSum = 0;
                int n = arr.Count;

                for (int i = 0; i < n; i++)
                {
                    primaryDiagonalSum += arr[i][i];
                    secondaryDiagonalSum += arr[i][n - 1 - i];
                }
                return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            }

            public static void Main(string[] args)
            {
                List<List<int>> sampleMatrix = new List<List<int>>
            {
                new List<int> { 11, 2, 4 },
                new List<int> { 4, 5, 6 },
                new List<int> { 10, 8, -12 }
            };

                int result = diagonalDifference(sampleMatrix);
                foreach (var row in sampleMatrix)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
                Console.WriteLine("Output: " + result);
            }
        }
    }
