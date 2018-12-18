using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class CompanyGenerator : Generator
    {
        private string[] NameParts1 = { "Мега" , "Ультра", "Супер", "Микро", "Дюраль", "Титан", "Раша", "ИП", "ЗАО", "ОАО", "ООО"};
        private string[] NameParts2 = { " хим. ", " рус ", "хим-системс", " технолджис" , ""};
        private string[] NameParts3 = { " Продакшн", " Компани", " Лимитед", " Корпорейшн" };

        private List<string> companies;
        private List<string> addresses;
        private List<long> availableOwners;
        private List<long> generatedOwners;
        private List<string> phoneNumbers;
        private List<int> coworkersCounts;

        public string[] GeneratedCompanyNames => companies.ToArray();

        private string GeneratePhone()
        {
            return "+7(" + GetRandomInt(900, 910) + ") " + GetRandomInt(100, 999) + '-' + GetRandomInt(10, 99) + '-' + GetRandomInt(10, 99);
        }

        private string GenerateName()
        {  
            return GetRandom(NameParts1) + GetRandom(NameParts2) + GetRandom(NameParts3);
        }

        private void GenerateCompanyNames(List<string> comp, int count)
        {
            for(int i = 0; i < count; i++)
            {
                string name;
                do
                {
                    name = GenerateName();
                } while (comp.Contains(name));

                comp.Add(name);

                if(count % 10 == 0 && count > 0)
                {
                    Console.WriteLine("Generated company names: " + i);
                }
            }
        }

        private void GenerateAddresses(List<string> address, int count)
        {
            for (int i = 0; i < count; i++)
            {
                address.Add(GenerateAddress());
            }
        }

        private void GeneratePhones(List<string> phones, int count)
        {
            for (int i = 0; i < count; i++)
            {
                phones.Add(GeneratePhone());
            }
        }

        private void GenerateCoworkers(List<int> coworkers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                coworkers.Add(GetRandomInt(3, 1000));
            }
        }

        public void GenerateOwners(List<long> ownerList, int count)
        {
            for(int i = 0; i < count; i++)
            {
                long random = GetRandom(availableOwners);
                ownerList.Add(GetRandom(availableOwners));

                Console.WriteLine("Added to owner list: " + random);
            }
        }

        public CompanyGenerator(List<long> passportList)
        {
            availableOwners = passportList;

            foreach(long passport in passportList)
            {
                Console.WriteLine("Passport available: " + passport);
            }
        }

        public override string GenerateTable(int count)
        {
            companies = new List<string>();
            addresses = new List<string>();
            generatedOwners = new List<long>();
            phoneNumbers = new List<string>();
            coworkersCounts = new List<int>();

            GenerateCompanyNames(companies, count);

            GenerateAddresses(addresses, count);

            GenerateOwners(generatedOwners, count);

            GeneratePhones(phoneNumbers, count);
            GenerateCoworkers(coworkersCounts, count);

            string result = "";

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("(Company) Passport printed to file: " + generatedOwners[i]);

                string line = "(";
                line += '\'' + companies.ToList()[i] + '\'' + ",";
                line += '\'' + addresses[i] + '\'' + ",";
                line += "\'" + generatedOwners[i] + "\'" + ",";
                line += "\'" + phoneNumbers[i] + "\'"+',';
                line += coworkersCounts[i].ToString();

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
