using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace LINQLab.LinqToSql
{
    [Table(Name = "Products")]
    class ProductsWrapper
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id;
        [Column]
        public string ProductName;
        [Column]
        public int EngineType;
        [Column]
        public string CompanyProducer;
        [Column]
        public float MolecularMass;
        [Column]
        public float PricePerLiter;
    }
}
