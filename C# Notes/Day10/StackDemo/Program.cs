namespace StackDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LIFO
            Stack<int> st = new Stack<int>();

            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(5);

            Console.WriteLine("Printing stack: ");
            foreach (int i in st) 
            { 
                Console.WriteLine(i);

            }

            Console.WriteLine("Popping: ");
            int popEl = st.Pop();
            Console.WriteLine(popEl);

            Console.WriteLine("Printing stack: ");
            while (st.Count > 0)
            {
                int top = st.Pop();
                Console.WriteLine(top);
            }

            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(5);

            Console.WriteLine("Peeking top: ");
            Console.WriteLine(st.Peek());

            Console.ReadLine();
        }
    }
}
