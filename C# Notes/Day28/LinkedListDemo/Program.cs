namespace LinkedListDemo
{   
    public class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null;
        }
    }
    public class LinkedList
    {
        private Node head;
        public void insertStart(int value)
        {
            Node newNode = new Node(value);
            if(head == null)
            {
                head = newNode;
            }
            else 
            {
                Node temp = head;
                head = newNode;
                head.next = temp;
            }
        }
        public void insertEnd(int value)
        {
            Node newNode = new Node(value);
            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }
        public void insertAfter(int value, int target)
        {
            Node newNode = new Node(value);
            Node temp = head;
            while (temp != null && temp.data != target)
            {
                temp = temp.next;
            } 
            if(temp == null)
            {
                Console.WriteLine("Target not present");
            }
            else
            {
                Node nextOfTarget = temp.next;
                temp.next = newNode;
                newNode.next = nextOfTarget;
            }
        }
        public void deleteNode(int target)
        {
            if(head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if(head.data == target)
            {
                head = head.next;
                return;
            }
            Node temp = head;
            while (temp.next != null && temp.next.data != target)
            {
                temp = temp.next;
            }
            if(temp.next != null)
            {
                Node nextOfTarget = temp.next.next;
                temp.next = nextOfTarget;
            }
        }
        public bool Search(int value)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.data == value) return true;
                temp = temp.next;
            }
            return false;
        }

        public void Display()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }
            Console.WriteLine("null");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList();

            // Testing Insertions
            myList.insertEnd(10);
            myList.insertEnd(20);
            myList.insertStart(5);      // List: 5 -> 10 -> 20 -> null
            myList.insertAfter(15, 10); // List: 5 -> 10 -> 15 -> 20 -> null

            Console.WriteLine("Current List:");
            myList.Display();

            // Testing Search
            Console.WriteLine("Search for 15: " + myList.Search(15));

            // Testing Deletion
            myList.deleteNode(10);      // List: 5 -> 15 -> 20 -> null
            Console.WriteLine("After deleting 10:");
            myList.Display();
        }
    }
}
