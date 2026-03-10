using System.Text.RegularExpressions;

namespace Q5
{
    public interface IFeedable
    {
        void Feed();
    }
    public abstract class Animal: IFeedable
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public abstract string Speak();
        public abstract void Feed();

        public override string ToString()
        {
            return $"{Name} {GetType().Name} says {Speak()}";
        }
    }
    public class Lion : Animal
    {
        public Lion(string Name) : base(Name) { }
        public override string Speak()
        {
            return "Roar";
        }
        public override void Feed()
        {
            Console.WriteLine($"{Name} is eating meat");
        }
    }
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name) { }

        public override string Speak() => "Trumpet";

        public override void Feed()
        {
            Console.WriteLine($"{Name} is eating grass.");
        }
    }
    public class Monkey : Animal
    {
        public Monkey(string name) : base(name) { }

        public override string Speak() => "Chatter";

        public override void Feed()
        {
            Console.WriteLine($"{Name} is eating bananas.");
        }
    }
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
        public void RemoveAnimal(string name)
        {
            animals.RemoveAll(x => x.Name == name);
        }
        public void FeedAll()
        {
            foreach (Animal animal in animals)
            {
                animal.Feed();
            }
        }
        public void CountByType()
        {
            var grouped = animals.GroupBy(x => x.GetType().Name);
            foreach(var g in grouped)
            {
                Console.WriteLine($"{g.Key}: {g.Count()}");
            }
        }
        public void ShowAll()
        {
            foreach (var animal in animals)
                Console.WriteLine(animal);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
                Zoo zoo = new Zoo();

                zoo.AddAnimal(new Lion("Simba"));
                zoo.AddAnimal(new Elephant("Dumbo"));
                zoo.AddAnimal(new Monkey("George"));
                zoo.AddAnimal(new Lion("Mufasa"));

                zoo.ShowAll();

                Console.WriteLine("\nFeeding Animals:");
                zoo.FeedAll();

                Console.WriteLine("\nAnimal Count:");
                zoo.CountByType();
                Console.ReadLine();
        }
    }
}