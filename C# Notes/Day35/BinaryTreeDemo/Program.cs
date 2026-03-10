namespace BinaryTreeDemo
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
        public static TreeNode CreateTree()
        {
            Console.WriteLine("Enter data: ");
            int data = Convert.ToInt32(Console.ReadLine());
            if(data == -1)
            {
                return null;
            }
            TreeNode node = new TreeNode(data);
            Console.WriteLine($"Enter data left of {data}");
            node.Left = CreateTree();
            Console.WriteLine($"Enter data right of {data}");
            node.Right = CreateTree();

            return node;
        }
        public static void InOrder(TreeNode node)
        {
            if(node == null)
            {
                return;
            }
            InOrder(node.Left); 
            Console.Write(node.Data+" ");
            InOrder(node.Right);
        }
        public static void PreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.Data+" ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
        public static void PostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Data+" ");
        }

        static void Main(string[] args)
        {
            TreeNode root = CreateTree();

            Console.WriteLine("\nPRE-ORDER");
            PreOrder(root);

            Console.WriteLine("\nIN-ORDER");
            InOrder(root);

            Console.WriteLine("\nPOST-ORDER");
            PostOrder(root);

            Console.ReadLine();
        }
    }
}
