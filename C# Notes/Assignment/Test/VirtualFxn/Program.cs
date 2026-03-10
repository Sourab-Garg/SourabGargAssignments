namespace VirtualFxn
{

    class Animal
    {
        public virtual void Sound()
        {
            Console.WriteLine("Animal make sound");
        }
    }

    class Dog : Animal 
    {
        public override void Sound() 
        {
            Console.WriteLine("Dog make sound");
        } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal obj1 = new Animal();
            Dog obj2 = new Dog();

            obj1.Sound();
            obj2.Sound();   

            Console.ReadLine();
        }
    }
}
