namespace Q4
{
    public class Property
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Property(int id, string location, double price, string type)
        {
            Id = id;
            Location = location;
            Price = price;
            Type = type;

        }
        public override string ToString()
        {
            return $"ID {Id} | Location {Location} | Price {Price} | Type {Type}";
        }

    }
    public class PropertyManager 
    {
        List<Property> properties = new List<Property>();
        public void AddProperty(Property property)
        {
            if (properties.Any(p => p.Id == property.Id))
            {
                throw new Exception("Duplicate ID's are not allowed");
            }
            properties.Add(property);
        }
        public void RemoveProperty(Property property)
        {
            properties.Remove(property);
        }
        public List<Property> FilterByProperty(string location)
        {
            return properties.Where(x => x.Location == location).ToList();
        }
        public List<Property> FilterByPriceRange(double min, double max)
        {
            return properties.Where(x => x.Price >= min && x.Price <= max).ToList();
        }
        public List<Property> GetAllSortedByPrice()
        {
            return properties.OrderBy(x=>x.Price).ToList();
        }
        public List<Property> GetAllSortedByLocationThenPrice()
        {
            return properties.OrderBy(x => x.Location).ThenBy(x=> x.Price).ToList(); 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PropertyManager manager = new PropertyManager();

            manager.AddProperty(new Property(1, "Delhi", 5000000, "Villa"));
            manager.AddProperty(new Property(2, "Mumbai", 3000000, "Apartment"));
            manager.AddProperty(new Property(3, "Delhi", 4500000, "Office"));

            Console.WriteLine("Sorted By Price:");
            foreach (var p in manager.GetAllSortedByPrice())
                Console.WriteLine(p);

            Console.WriteLine("\nSorted By Location Then Price:");
            foreach (var p in manager.GetAllSortedByLocationThenPrice())
                Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
