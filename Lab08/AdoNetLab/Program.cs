using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = new[] {1, 2, 3};
            PrintCollection(values);
            List<double> list = new List<double>() {1, 2, 3};
            PrintCollection(list);

            Console.ReadKey();
        }

        static void PrintCollection(ICollection collection)
        {
            foreach (var element in collection)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}
