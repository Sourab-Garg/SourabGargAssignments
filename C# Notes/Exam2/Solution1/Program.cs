namespace Solution1
{
    class Supplier
    {
        public string SupplierID { get; set; }
        public string Name { get; set; }
        public string Contact { get;set; }
        public int ProductsSupplied { get; set; }
        public double Rating { get; set; }

        public static List<Supplier> Retrieve()
        {
            List<Supplier> initialSuppliers = new List<Supplier>()
            {
                new Supplier() {SupplierID = "101", Name = "ABC", Contact="1991", ProductsSupplied = 102, Rating = 8.2 },

                new Supplier() {SupplierID = "102", Name = "ABC", Contact = "1992", ProductsSupplied = 110, Rating = 7.2 },

                new Supplier() {SupplierID = "103", Name = "GHI", Contact = "1993", ProductsSupplied = 105, Rating = 3.2 },

                new Supplier() {SupplierID = "104", Name = "JKL", Contact = "1994", ProductsSupplied = 170, Rating = 5.2 },

                new Supplier() {SupplierID = "105", Name = "MNO", Contact = "1995", ProductsSupplied = 104, Rating = 8.8 },

                new Supplier() {SupplierID = "106", Name = "PQR", Contact = "1996", ProductsSupplied = 120, Rating = 2.6 },

                new Supplier() {SupplierID = "107", Name = "STU", Contact = "1997", ProductsSupplied = 109, Rating = 5.9 }
            };

            return initialSuppliers;
        }

        public static void InsertSupplier(Supplier newSupplier,List<Supplier> list)
        {
            list.Add(newSupplier);
        }

        public static void UpdateSupplierName(string ID, string NewName, List<Supplier> list)
        {
            foreach (Supplier supplier in list)
            {
                if (supplier.SupplierID == ID)
                {
                    supplier.Name = NewName;
                    return;
                }
            }
            Console.WriteLine($"{ID} not found!, No updation.");
        }

        public static void DeleteSupplier(string ID, List<Supplier> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].SupplierID == ID)
                {
                    list.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($"{ID} not found!, nothing is deleted.");
        }

        public static Supplier GetSupplier(string ID, List <Supplier> list) 
        {
            Supplier supplier = null;
            
            foreach(Supplier sc in list) 
            {
                if (sc.SupplierID == ID)
                { 
                    supplier = sc;
                    break;
                }
            }

            return supplier;
        }

        public static void DisplayAllSuppliers(List<Supplier> list)
        {
            foreach(Supplier supplier in list)
            {
                Console.WriteLine(supplier.SupplierID + " " + supplier.Name);
            }
        }

        public static List<Supplier> SearchSuppliersByRating(double minRating, List<Supplier> list)
        {
            List<Supplier> ratingList = new List<Supplier>();

            foreach (Supplier supplier in list)
            { 
                if(supplier.Rating > minRating)
                {
                    ratingList.Add(supplier); 
                }
            }

            return ratingList;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Supplier> mainList = Supplier.Retrieve();

            Supplier newSupplier = new Supplier()
            { 
                SupplierID = "107", Name = "XYZ", Contact = "911", ProductsSupplied = 922, Rating = 9.0
            };

            Supplier.InsertSupplier(newSupplier, mainList);
            Supplier.UpdateSupplierName("102", "DEF", mainList);

            Supplier.DeleteSupplier("102", mainList);

            string tempId = "1013";
            Supplier getSupplier = Supplier.GetSupplier("103", mainList);
            if (getSupplier != null)
            {
                Console.WriteLine($"Supplier fetched of ID {tempId} with name '{getSupplier.Name}'.");
            }
            else
            {
                Console.WriteLine($"Supplier of ID {tempId} not found!");
            }


            Console.WriteLine("Printing all suppliers: ");
            Supplier.DisplayAllSuppliers(mainList);

            double minRating = 4.0;
            Console.WriteLine($"Supplier with rating above: {minRating}");
            List<Supplier> minRatedSuppliers = Supplier.SearchSuppliersByRating(minRating, mainList);
            if (minRatedSuppliers.Count > 0)
            {
                Supplier.DisplayAllSuppliers(minRatedSuppliers);
            }
            else
            {
                Console.WriteLine($"No supplier above {minRating} is found!");
            }

            Console.ReadLine();
        }
    }
}
