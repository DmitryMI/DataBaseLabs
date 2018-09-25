using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    abstract class Generator
    {
        private static Random Random = new Random((int)DateTime.Now.Ticks);
        public static T GetRandom<T>(ICollection<T> array)
        {
            int index = Random.Next(0, array.Count() - 1);
            return array.ElementAt(index);
        }

        public abstract string[] GenerateTable(int count);
    }
}
