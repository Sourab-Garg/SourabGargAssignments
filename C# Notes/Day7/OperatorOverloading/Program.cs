namespace OperatorOverloading
{

    class ABCD
    {
        public int a;
        public ABCD()//Default constructor
        {

        }
        public ABCD(int k)//parametizwed constructor
        {
            a = k;
        }
        public static ABCD operator +(ABCD obj1, ABCD obj2)
        {
            ABCD temp = new ABCD();
            temp.a = obj1.a + obj2.a;
            Console.WriteLine($"The sum of two objects is {temp.a}");
            return temp;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {   
            int x = 10;
            int y = 20;
            int z = x + y;

            ABCD obj1 = new ABCD(100);
            ABCD obj2 = new ABCD(200);
            ABCD obj3 = new ABCD();
            obj3 = obj1 + obj2;
            Console.WriteLine(obj3.a);

            Console.ReadLine();

        }
    }
}