using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace LINQLab.LinqToSql
{
    [Table(Name = "Owners")]
    class OwnersWrapper
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;
        [Column]
        public int Passport;
        [Column]
        public string FullName;
        [Column]
        public string LivingAddress;
        [Column]
        public string HasEducation;
        [Column]
        public string Sex;
    }
}
