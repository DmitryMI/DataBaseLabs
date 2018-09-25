using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorConsole
{
    class ChemGenerator : Generator
    {
        private HashSet<string> productNames;
        private List<string> motorTypes;
        private List<string> pricePerLiter;
        private List<string> companyNames;

        private string[] availableCompanies;

        public ChemGenerator(CompanyGenerator companyGenerator)
        {
            availableCompanies = companyGenerator.GeneratedCompanyNames;
        }

        public override string[] GenerateTable()
        {
            
        }
        
    }
}
