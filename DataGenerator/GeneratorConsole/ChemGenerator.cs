using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class ChemGenerator : Generator
    {
        private List<string> productNames;
        private List<string> motorTypes;
        private List<double> pricePerLiter;
        private List<string> companyNames;
        private List<double> massList;

        private string[] availableCompanies;

        private string[] namePart1 = { "Power", "Speed", "Master", "Magic", "Coca-colas", "Turbo", "Liquid", "Solid", "Nitro"};
        private string[] namePart2 = { "Oil", "Petrol", "Benzene", "Gasoline", "Booster", "Man", "Sonic", "Knuckles" };
        private string[] namePart3 = { "95", "98", "1000", "2000", "2k18" };

        private string[] engineModels = { "Автомобильный", "Авиационный поршневой", "Авиационный турбореактивный", "Ракетный" };

        public ChemGenerator(CompanyGenerator companyGenerator)
        {
            availableCompanies = companyGenerator.GeneratedCompanyNames;
        }

        private string GenerateName()
        {
            return GetRandom(namePart1) + ' ' + GetRandom(namePart2) + ' ' + GetRandom(namePart3);
        }

        private void GenerateNames(List<string> namesList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                /*bool ok = namesList.Add(GenerateName());
                if (!ok)
                    i--;*/

                string name;
                do
                {
                    name = GenerateName();
                } while (namesList.Contains(name));

                namesList.Add(name);

                if (count % 10 == 0 && count > 0)
                {
                    Console.WriteLine("Generated product names: " + i);
                }
            }
        }

        private void GenerateEngineTypes(List<string> types, int count)
        {
            for (int i = 0; i < count; i++)
            {
                types.Add(GetRandom(engineModels));
            }
        }

        private void GenerateProducor(List<string> produsors, int count)
        {
            for (int i = 0; i < count; i++)
            {
                produsors.Add(GetRandom(availableCompanies));
            }
        }

        private void GenerateMolecularMass(List<double> mass, int count)
        {
            for (int i = 0; i < count; i++)
            {
                mass.Add(GetRandomDouble(100, 200));
            }
        }

        private void GeneratePrice(List<double> price, int count)
        {
            for (int i = 0; i < count; i++)
            {
                price.Add(GetRandomDouble(300, 1000));
            }
        }

        public override string GenerateTable(int count)
        {
            productNames = new List<string>();
            pricePerLiter = new List<double>();
            massList = new List<double>();
            companyNames = new List<string>();
            motorTypes = new List<string>();

            GenerateEngineTypes(motorTypes, count);
            GenerateMolecularMass(massList, count);
            GenerateNames(productNames, count);
            GenerateProducor(companyNames, count);
            GeneratePrice(pricePerLiter, count);

            string result = "";

            IFormatProvider format = CultureInfo.CreateSpecificCulture("en");

            for (int i = 0; i < count; i++)
            {
                string priceStr = pricePerLiter[i].ToString("0.00", format);
                string massStr = massList[i].ToString("0.00", format);

                string line = "(";
                line += '\'' + productNames.ToList()[i] + '\'' + ",";
                line += '\'' + motorTypes[i] + '\'' + ",";
                line += '\'' + companyNames[i] + '\'' + ",";
                line += priceStr + ',';
                line += massStr;

                line += ')';

                if (i < count - 1)
                {
                    line += ',';
                }

                result += line + '\n';
            }

            return result;
        }
        
    }
}
