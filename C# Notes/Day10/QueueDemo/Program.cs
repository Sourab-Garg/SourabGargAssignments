namespace QueueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.Enqueue("D");

            Console.WriteLine("Printing: ");
            foreach (string item in queue)
            {
                Console.WriteLine(item);
            }

            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Peek());
                queue.Dequeue();
            }

            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            queue.Enqueue("D");

            Console.WriteLine("Dequeue: ");
            queue.Dequeue();

            Console.ReadLine();
        }
    }
}
