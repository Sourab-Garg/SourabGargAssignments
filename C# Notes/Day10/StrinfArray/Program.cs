namespace StrinfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[4]
            {
                "Ramu",
                "Ram",
                "As",
                "Sourab"
            };
            int max = int.MinValue;
            int min = int.MaxValue;

            //foreach (string s in arr)
            //{
            //    if(s.Length > max)
            //    {
            //        max = s.Length;
            //    }
            //    if (s.Length < min)
            //    {
            //        min = s.Length;
            //    }
            //}

            int maxIdx = -1;
            int minIdx = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > max)
                {
                    max = arr[i].Length;
                    maxIdx = i;
                }
                if (arr[i].Length < min)
                {
                    min = arr[i].Length;
                    minIdx = i;
                }
            }



            Console.WriteLine($"Max string is {arr[maxIdx]} of size {max} at index {maxIdx}. \nMin string is {arr[minIdx]} of size {min} at index {minIdx}.");

            Console.ReadLine();
        }
    }
}
