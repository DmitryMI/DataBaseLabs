using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class OwnerGenerator : Generator
    {
        private long minPassport= 135000;
        private long maxPassport = 140000;
        private List<long> passports;
        private List<string> names;
        private List<string> addresses;
        private List<bool> hasEducations;
        private List<bool> sexes;

        private string[] lastNames = {"Попов", "Петров", "Сидоров", "Качалкин", "Куклушев", "Авакумов", "Щукин"};
        private string[] firstNamesMale = {"Виталий", "Венеамин", "Виктор", "Андрей", "Антон"};
        private string[] fatherNamesMale = {"Витальевич", "Венеаминович", "Викторович", "Андреевич", "Антонович"};

        private string[] firstNamesFemale = {"Мария", "Анна", "Маргарита", "Вероника", "Любовь", "Надежда"};
        private string[] fatherNamesFemale = { "Витальевна", "Венеаминовна", "Викторовна", "Андреевна", "Антоновна" };

        private string GenerateName(bool male)
        {
            string lastName = GetRandom(lastNames);
            if (!male)
                lastName += 'а';
            string father, name;
            if (!male)
            {
                father = GetRandom(fatherNamesFemale);
                name = GetRandom(firstNamesFemale);
            }
            else
            {
                father = GetRandom(fatherNamesMale);
                name = GetRandom(firstNamesMale);
            }            


            return lastName + ' ' + name + ' ' + father;
        }        

        private void GenerateNameSex(List<string> names, List<bool> sexes, int count)
        {
            for(int i= 0; i < count; i++)
            {
                bool sex = GetRandomBool();
                sexes.Add(sex);
                names.Add(GenerateName(sex));
            }            
        }

        private void GeneratePassports(List<long> passports, int count)
        {
            for (int i = 0; i < count; i++)
            {
                /* bool ok = passports.Add(GetRandomLong(minPassport, maxPassport));
                 if (!ok)
                     i--;*/
                long passport;
                do
                {
                    passport = GetRandomLong(minPassport, maxPassport);
                } while (passports.Contains(passport));

                passports.Add(passport);

                Console.WriteLine("Passport generated: " + passport);
            }
        }

        private void GenerateBoolList(List<bool> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(GetRandomBool());
            }
        }

        private void GenerateAddresses(List<string> address, int count)
        {
            for (int i = 0; i < count; i++)
            {
                address.Add(GenerateAddress());
            }
        }

        public List<long> Passports => passports;

        private string SexBoolToString(bool val)
        {
            return val ? "Male" : "Female";
        }

        private string EducationBoolToString(bool val)
        {
            return val ? "True" : "False";
        }

        public override string GenerateTable(int count)
        {
            names = new List<string>();
            passports = new List<long>();
            addresses = new List<string>();
            hasEducations = new List<bool>();
            sexes = new List<bool>();

            string result = "";

            GenerateNameSex(names, sexes, count);
            GenerateAddresses(addresses, count);
            GeneratePassports(passports, count);
            GenerateBoolList(hasEducations, count);

            for (int i = 0; i < count; i++)
            {
                string line = "(";
                line += passports[i];
                line += ',';
                line += '\'' + names[i] + '\'' + ",";
                line += "\'"+ addresses[i] + '\'' + ",";
                line += "\'" + EducationBoolToString(hasEducations[i]) + "\'" +  ",";
                line += '\'' + SexBoolToString(sexes[i]) + '\'';

                line += ')';

                if(i < count - 1)
                {
                    line += ',';                    
                }

                result += line + '\n';
            }

            return result;
        }

        
    }
}
