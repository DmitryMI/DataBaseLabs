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

        private static string[] cities = { "Москва", "Саратов", "Екатеринбург", "Волгоград", "Самара", "Уфа", "Тольятти", "Торжок"};
        private static string[] streets = { "Строителей", "Ленина", "Октябрьской Революции", "Пролетарская", "Трактористов", "Волейболистов", "Пловцов", "Сталина" };
      
        public static T GetRandom<T>(ICollection<T> array)
        {
            int index = Random.Next(0, array.Count());
            return array.ElementAt(index);
        }

        public static bool GetRandomBool()
        {
            int val = Random.Next(0, 2);

            return val == 0;
        }

        public static int GetRandomInt(int start, int end)
        {
            return Random.Next(start, end);
        }

        public static long GetRandomLong(long start, long end)
        {
            double val = Random.NextDouble();
            return (long)(((double)end - start) * val + (double)start);
        }

        public static string GenerateAddress()
        {
            return "г. " + GetRandom(cities) + ", ул. " + GetRandom(streets) + ", д. " + GetRandomInt(1, 100);
        }

        public static double GetRandomDouble(double start, double end)
        {
            return Random.NextDouble() * (end - start) + start;
        }

        public abstract string GenerateTable(int count);
    }
}
