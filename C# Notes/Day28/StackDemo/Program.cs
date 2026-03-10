namespace StackDemo
{
    public class Stack
    {
        private int[] arr;
        private int maxSize;
        private int top;

        public Stack(int size)
        {
            arr = new int[size];
            top = -1;
            maxSize = size;
        }
        public bool isFull()
        {
            if (top == maxSize-1)
            {
                return true;
            }
            return false;
        }

        public bool isEmpty()
        {
            if(top == -1)
            {
                return true;
            }
            return false;
        }

        public void push(int el)
        {
            if (isFull())
            {
                Console.WriteLine("Stack Overflow!");
                return;
            }
            top++;
            arr[top] = el;
        }
        public int pop() 
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack Underflow!");
                return -1;
            }
            int value = arr[top];
            top--;
            return value;
        }
        public int peek()
        {
            if (isEmpty())
            {
                return -1;
            }
            return arr[top];    
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack(5);
            s.pop();
            s.push(3);
            s.push(33);
            s.peek();
            s.pop();
            s.pop();
            s.pop();
        }
    }
}
