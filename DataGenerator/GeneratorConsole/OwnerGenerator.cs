using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class OwnerGenerator : Generator
    {
        private HashSet<string> names;
        private string[] lastNames = {"Попов, Петров, Сидоров, Качалкин, Куклушев, Авакумов, Щукин"};
        private string[] firstNamesMale = {"Виталий", "Венеамин", "Виктор", "Андрей", "Антон"};
        private string[] fatherNameMale = {"Витальевич", "Венеаминович", "Викторович", "Андреевич", "Антонович"};

        private string[] firstNamesFemale = {"Мария", "Анна", "Маргарита", "Вероника", "Любовь", "Надежда"};
        private string[] fatherNameFemale = { "Витальевна", "Венеаминовна", "Викторовна", "Андреевна", "Антоновна" };

        private string GenerateName()
        {
            return Generator.GetRandom();
        }

        public override string[] GenerateTable(int count)
        {
            names = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                
            }
        }

        
    }
}
