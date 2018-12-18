using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLab
{
    static class LinqQueries
    {
        static Random _rnd = new Random();
        private static bool IsNumber(char symbol)
        {
            int result;
            string str = "" + symbol;
            bool success = Int32.TryParse(str, out result);
            return success;
        }

        private static bool StartsWithNumber(string str)
        {
            return IsNumber(str[0]);
        }

        private static string GetRandomString(int len)
        {
            int min = 'a';
            int max = 'z';
            string result = "";
            for(int i = 0; i < len; i++)
            {
                char symbol = (char)_rnd.Next(min, max + 1);
                result += symbol;
            }

            return result;
        }

        public static void Query1()
        {
            // Выбор всех строк, начинающихся с числа
            string[] strs = { "abc", "cdb", "5gb", "fdv", "6hn", "3fv" };

            var selected =
                from s in strs
                where StartsWithNumber(s)
                orderby s
                select s;

            foreach (string s in selected)
                Console.WriteLine(s);
        }

        public static void Query2()
        {
            // Выбор всех строк, начинающегося с числа из двух массивов
            string[] strs1 = { "abc", "cdb", "5gb", "fdv", "6hn", "3fv" };
            string[] strs2 = { "ooo", "4trr", "6yyy" };

            var selected =
                (from s in strs1
                 where StartsWithNumber(s)
                 orderby s
                 select s)
                .Union(
                        from s in strs2
                        where StartsWithNumber(s)
                        orderby s
                        select s
                    );

            foreach (string s in selected)
                Console.WriteLine(s);
        }

        public static void Query3()
        {
            // Первый запрос с использованием вложенного запроса в where

            string[] strs = { "abc", "cdb", "5gb", "fdv", "6hn", "3fv" };

            var selected =
                from s in strs
                where 
                    (
                    from c in s
                    where IsNumber(c) && s.First() == c
                    orderby c
                    select c
                    ).Count() == 1
                orderby s
                select s;

            foreach (string s in selected)
                Console.WriteLine(s);
        }

        public static void Query4()
        {
            // Выбор всех строк, имеющих буквы a на второй позиции
            string[] strs = { "abc", "cdb", "5gb", "fdv", "6an", "3fv", "iao" };

            var selected =
                from s in strs
                where 
                    (
                    s.ElementAt(1) == 'a'
                    )
                orderby s
                select s;

            foreach (string s in selected)
                Console.WriteLine(s);
        }

        public static void Query5()
        {
            // Использование переменных. Добавление ко всем строкам случайной строки
            string[] strs = { "aaa1", "aaa2", "aaa3", "aaa4"};

            var selected =
                from s in strs
                let rand = GetRandomString(3)
                orderby s
                select rand + s;

            foreach (string s in selected)
                Console.WriteLine(s);
        }
    }
}
