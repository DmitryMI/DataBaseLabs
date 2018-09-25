using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class Program
    {
        private static HashSet<string> productNames;
        private static List<string> motorTypes;
        private static List<string> pricePerLiter;
        private static HashSet<string> companyNames;

        static void Main(string[] args)
        {
            OwnerGenerator ownerGenerator = new OwnerGenerator();            
            string ownerTable = ownerGenerator.GenerateTable(100);

            Console.WriteLine("Owner table generated");

            CompanyGenerator companyGenerator = new CompanyGenerator(ownerGenerator);

            string companyTable = companyGenerator.GenerateTable(100);

            string productTable = new ChemGenerator(companyGenerator).GenerateTable(100);

            File.WriteAllText("owners.txt", ownerTable);
            File.WriteAllText("companies.txt", companyTable);
            File.WriteAllText("products.txt", productTable);
        }
    }
}
