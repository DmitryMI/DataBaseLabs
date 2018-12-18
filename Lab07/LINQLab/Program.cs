using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();        
        }

        static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. LINQ Queries");
                Console.WriteLine("2. LINQ to XML");
                Console.WriteLine("3. LINQ to SQL\n");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:
                        exit = true;
                        break;
                        
                    case 1:
                        DoQueries();
                        break;
                    case 2:
                        DoXmlRead();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        DoXmlUpdate();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        DoXmlAdd();
                        break;
                    case 3:
                        LinqToSql.LinqToSql.ReadDb();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                                                
                        LinqToSql.LinqToSql.SimpleQuery();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        LinqToSql.LinqToSql.MultiTableQuery();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        LinqToSql.LinqToSql.UpdateTable();
                         Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        LinqToSql.LinqToSql.AddAndDeleteCompany();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        LinqToSql.LinqToSql.CallProcedure();
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            
        }

        static void DoQueries()
        {
            Console.WriteLine("Query 1: ");
            LinqQueries.Query1();

            Console.WriteLine("\nQuery 2: ");
            LinqQueries.Query2();

            Console.WriteLine("\nQuery 3: ");
            LinqQueries.Query3();

            Console.WriteLine("\nQuery 4: ");
            LinqQueries.Query4();

            Console.WriteLine("\nQuery 5: ");
            LinqQueries.Query5();
        }

        static void DoXmlRead()
        {
            Console.WriteLine("Reading from XML: ");
            LinqToXml.ReadFromXml();
        }

        static void DoXmlUpdate()
        {
            Console.WriteLine("Updating XML: ");
            LinqToXml.UpdateXml();
            FileInfo info = new FileInfo(LinqToXml.PathToUpdatedXml);
            Console.WriteLine("Update complete! Look inside file: " + info.FullName);
        }

        static void DoXmlAdd()
        {
            Console.WriteLine("Adding to XML");
            LinqToXml.AddToXml();
            FileInfo info = new FileInfo(LinqToXml.PathToWrittenXml);
            Console.WriteLine("Adding complete! Look inside file: " + info.FullName);
        }
    }
}
