namespace RunTimePoly
{
    class Dog
    {
        public virtual void bark()
        {
            Console.WriteLine("Dog bark!");
        }
    }

    class Husky : Dog
    {
        public override void bark()
        {
            Console.WriteLine("Husky bark!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Dog objd = new Dog();
            //Husky objh = new Husky();

            //objd.bark();
            //objh.bark();

            Dog dog = new Husky();
            Dog hug = new Dog();

            dog.bark();
            hug.bark();

            Console.ReadLine();
        }
    }
}
