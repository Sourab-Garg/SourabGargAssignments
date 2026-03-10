using System;
using System.Collections.Generic;

namespace GenericClasses
{
    // 1. GENERIC CLASS with 2 parameters (TKey and TValue)
    // We use constraints (where) to ensure the Key is never null
    public class MyDictionary<TKey, TValue> where TKey : notnull
    {
        private List<TKey> _keys = new List<TKey>();
        private List<TValue> _values = new List<TValue>();

        // 2. GENERIC METHOD within a class
        public void AddEntry(TKey key, TValue value)
        {
            _keys.Add(key);
            _values.Add(value);
            Console.WriteLine($"Added: [{key}] = {value}");
        }

        public void DisplayAll()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                Console.WriteLine($"{_keys[i]}: {_values[i]}");
            }
        }
    }

    internal class Program
    {
        // 3. STATIC GENERIC FUNCTION (Works independently of the class)
        public static void SwapValues<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            // Usage of Generic Class with 2 parameters (int and string)
            var errorCodes = new MyDictionary<int, string>();
            errorCodes.AddEntry(404, "Not Found");
            errorCodes.AddEntry(200, "OK");
            errorCodes.AddEntry(500, "Server Error");

            Console.WriteLine("--- Dictionary Contents ---");
            errorCodes.DisplayAll();

            // Usage of Generic Function
            string first = "World", second = "Hello";
            SwapValues(ref first, ref second);
            Console.WriteLine($"\nSwapped: {first} {second}");
        }
    }
}