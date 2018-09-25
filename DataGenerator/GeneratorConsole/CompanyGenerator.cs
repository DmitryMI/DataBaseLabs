using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class CompanyGenerator : Generator
    {
        private HashSet<string> companies;

        public string[] GeneratedCompanyNames => companies.ToArray();
        public override string[] GenerateTable(int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                
            }
        }
    }
}
