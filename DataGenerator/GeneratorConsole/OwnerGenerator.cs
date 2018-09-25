using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class OwnerGenerator : Generator
    {
        private long minPassport= 4500000000;
        private long maxPassport = 4599999999;
        private HashSet<long> passports;
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

        private void GeneratePassports(HashSet<long> passports, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bool ok = passports.Add(GetRandomLong(minPassport, maxPassport));
                if (!ok)
                    i--;
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

        public List<long> Passports => passports.ToList();

       

        public override string GenerateTable(int count)
        {
            names = new List<string>();
            passports = new HashSet<long>();
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
                line += passports.ToList()[i];
                line += ',';
                line += '\'' + names[i] + '\'' + ",";
                line += '\'' + addresses[i] + '\'' + ",";
                line += hasEducations[i].ToString() + ',';
                line += sexes[i].ToString();

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
