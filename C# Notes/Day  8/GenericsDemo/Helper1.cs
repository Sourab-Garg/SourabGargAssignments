using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Helper1
    {
        public static void swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }

        public static T add1<T>(T x, T y)
        {
            dynamic a = x;
            dynamic b = y;
            Console.WriteLine("1: ");
            return a + b;
        }

        public static F add2<T, F>(T x, F y)
        {
            dynamic a = x;
            dynamic b = y;
            Console.WriteLine("2: ");
            return a + b;
        }
    }
}
