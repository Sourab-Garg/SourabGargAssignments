namespace BinaryTreeDemo2
{
    public class TreeNode
    {
        public int Data;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    internal class Program
    {
        // ==============================
        // INSERT INTO BST
        // ==============================
        public static TreeNode Insert(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }
            if (value < root.Data)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (value > root.Data)
            {
                root.Right = Insert(root.Right, value);
            }
            return root;
        }

        // ==============================
        // PREORDER (Root → Left → Right)
        // ==============================
        public static void PreOrder(TreeNode root)
        {
            if (root == null)
                return;

            Console.Write(root.Data + " ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        // ==============================
        // INORDER (Left → Root → Right)
        // ==============================
        public static void InOrder(TreeNode root)
        {
            if (root == null)
                return;

            InOrder(root.Left);
            Console.Write(root.Data + " ");
            InOrder(root.Right);
        }

        // ==============================
        // POSTORDER (Left → Right → Root)
        // ==============================
        public static void PostOrder(TreeNode root)
        {
            if (root == null)
                return;

            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + " ");
        }

        // ==============================
        // SEARCH IN BST
        // ==============================
        public static bool Search(TreeNode root, int key)
        {
            if (root == null)
                return false;

            if (root.Data == key)
                return true;

            if (key < root.Data)
                return Search(root.Left, key);
            else
                return Search(root.Right, key);
        }

        static void Main(string[] args)
        {
            TreeNode root = null;

            Console.WriteLine("Enter numbers to insert into BST (-1 to stop):");

            while (true)
            {
                int value = Convert.ToInt32(Console.ReadLine());

                if (value == -1)
                    break;

                root = Insert(root, value);
            }

            Console.WriteLine("\nPRE-ORDER:");
            PreOrder(root);

            Console.WriteLine("\nIN-ORDER:");
            InOrder(root);

            Console.WriteLine("\nPOST-ORDER:");
            PostOrder(root);

            Console.WriteLine("\n\nEnter value to search:");
            int key = Convert.ToInt32(Console.ReadLine());

            if (Search(root, key))
                Console.WriteLine("Value Found");
            else
                Console.WriteLine("Value Not Found");

            Console.ReadLine();
        }
    }
}
