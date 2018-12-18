using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace LINQLab.LinqToSql
{
    [Table(Name = "Companies")]
    class CompanyWrapper
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;
        [Column]
        public string CompanyName;
        [Column]
        public string CompanyAddress;
        [Column]
        public int CompanyOwnerPassport;
        [Column]
        public string PhoneNumber;
        [Column]
        public int EmploeeCount;
        [Column]
        public double AnnualTurnover;

        public override string ToString()
        {
            return Id + " " + CompanyAddress + " " + CompanyOwnerPassport;
        }
    }
}
