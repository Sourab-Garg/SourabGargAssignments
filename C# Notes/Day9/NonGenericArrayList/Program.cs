using System.Collections;

namespace NonGenericArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList obj = new ArrayList();
            obj.Add(1);
            obj.Add(true);
            obj.Add("Ram");
            obj.Add(DateTime.Now);
            obj.Add(12.21);

            Console.WriteLine($"No of elements: {obj.Count}");
            Console.WriteLine($"Capacity: {obj.Capacity}");

            foreach(var el in obj)
            {
                Console.WriteLine(el); 
            }
            int[] fourmoew = new int[4] { 1, 2, 3 ,4};

            //foreach(var el in fourmoew)
            //{
            //    obj.Add(el);
            //}
            obj.AddRange(fourmoew);


            obj.Insert(0, "first");
            obj.RemoveAt(3);

            foreach (var el in obj)
            {
                Console.WriteLine(el);
            }

            Console.ReadLine();

        }
    }
}
