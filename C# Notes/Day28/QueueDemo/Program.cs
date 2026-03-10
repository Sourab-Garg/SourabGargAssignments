namespace QueueDemo
{
    public class Queue
    {
        private int[] arr;
        private int front;
        private int rear;
        private int maxSize;
        private int count;
        public Queue(int size)
        {
            arr = new int[size];
            front = 0;
            rear = 0;
            maxSize = size;
            count = 0;
        }
        public bool isFull()
        {
            return count == maxSize;
        }
        public bool isEmpty()
        {
            return count == 0;
        }
        public void enqueue(int el)
        {
            if (isFull())
            {
                Console.WriteLine("Queue full");
                return;
            }
            count++;
            arr[rear] = el;
            rear = (rear + 1) % maxSize ;
        }
        public int dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue empty");
                return -1;
            }
            int x = arr[front];
            count--;
            front = (front+1) % maxSize ;
            return x;
        }
        public int peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue empty");
                return -1;
            }
            return arr[front];
        }
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue(5);
            q.enqueue(1);
            q.enqueue(2);
            q.dequeue();
        }
    }
}
