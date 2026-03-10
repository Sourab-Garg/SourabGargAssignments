namespace IndexerDemo
{
    class RecordStore
    {
        private string[] data = new string[5];

        // Defining the Indexer
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < data.Length)
                    return data[index];
                return "Out of Bounds";
            }
            set
            {
                if (index >= 0 && index < data.Length)
                    data[index] = value;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            RecordStore store = new RecordStore();

            // Using the indexer to SET values
            store[0] = "Classic Rock";
            store[1] = "Jazz";
            store[2] = "Blues";

            // Using the indexer to GET values
            Console.WriteLine(store[0]); // Output: Classic Rock
            Console.WriteLine(store[1]); // Output: Jazz
            Console.WriteLine(store[5]); // Output: Out of Bounds
        }
    }
}
