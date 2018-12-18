using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLab.LinqToSql
{
    class LinqToSql
    {
        private const int MaxRowOutput = 5;

        public const string connectionCmd = @"Data Source=DESKTOP-7C0V9B9;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=EngineChemicals";

        private static Table<CompanyWrapper> _companies;
        private static Table<ProductsWrapper> _products;
        private static Table<OwnersWrapper> _owners;
        private static UserDataContext _db;

        public static void ReadDb()
        {
            _db = new UserDataContext(connectionCmd);

            _companies = _db.GetTable<CompanyWrapper>();
            _products = _db.GetTable<ProductsWrapper>();
            _owners = _db.GetTable<OwnersWrapper>();

            Console.WriteLine("Sample data from companies: ");

            int rowCount = 0;            

            foreach(var company in _companies)
            {
                Console.WriteLine("{0}\t {1}", company.Id, company.CompanyName);

                rowCount++;
                if (rowCount >= MaxRowOutput)
                {
                    rowCount = 0;
                    break;
                }
            }           

            Console.WriteLine("\nSample data from products: ");

            foreach (var product in _products)
            {
                Console.WriteLine("{0}\t {1}", product.MolecularMass, product.ProductName);

                rowCount++;
                if (rowCount >= MaxRowOutput)
                {
                    rowCount = 0;
                    break;
                }
            }

            Console.WriteLine("\nSample data from owners: ");

            foreach (OwnersWrapper owner in _owners)
            {
                Console.WriteLine("{0}\t {1}", owner.Id, owner.FullName);

                rowCount++;
                if (rowCount >= MaxRowOutput)
                {
                    rowCount = 0;
                    break;
                }
            }
        }

        public static void SimpleQuery()
        {
            Console.WriteLine("Searching for rich companies");

            // Поиск всех богатых компаний
            var result = from row in _companies
                         where row.AnnualTurnover > 95
                         select row;

            foreach(var unit in result)
            {
                Console.WriteLine(unit.Id + "\t" + unit.CompanyName + "\t" + unit.AnnualTurnover);
            }
        }

        public static void MultiTableQuery()
        {
            Console.WriteLine("Searching for owners of rich companies");
            // Поиск всех владельцев богатых компаний
            var result = from owner in _owners
                         where
                         (
                            from company in _companies
                            where (company.CompanyOwnerPassport == owner.Passport && company.AnnualTurnover > 95)
                            select company
                         ).Count() > 0
                         select owner;

            foreach (var owner in result)
            {
                Console.WriteLine(owner.Id + "\t" + owner.FullName);
            }
        }

        public static void UpdateTable()
        {
            Console.WriteLine("Updating table");

            // Изменение оборота самой богатой компании на "999999"
            var result = from company in _companies
                         orderby -company.AnnualTurnover
                         select company;
            result.First().AnnualTurnover = 999999;

            _db.SubmitChanges();

            // Поиск всех богатых компаний
            var richest = from row in _companies
                         where row.AnnualTurnover > 99
                         select row;

            foreach (var unit in richest)
            {
                Console.WriteLine(unit.Id + "\t" + unit.CompanyName + "\t" + unit.AnnualTurnover);
            }

            // Отмена изменений
            result.First().AnnualTurnover = 99.9999;

            _db.SubmitChanges();
        }

        public static void AddAndDeleteCompany()
        {
            Console.WriteLine("Adding a company");

            CompanyWrapper nRow = new CompanyWrapper();
            nRow.CompanyName = "Новая компания";
            nRow.CompanyOwnerPassport = 1234567;
            nRow.EmploeeCount = 1;
            nRow.CompanyAddress = "Улица Случайная, дом Рандом";
            nRow.AnnualTurnover = 100;
            nRow.PhoneNumber = "+7905 77 55 44 3";

            _companies.InsertOnSubmit(nRow);

            _db.SubmitChanges();

            // Поиск всех богатых компаний
            var richest = from row in _companies
                          select row;

            foreach (var unit in richest)
            {
                Console.WriteLine(unit.Id + "\t" + unit.CompanyName + "\t" + unit.AnnualTurnover);
            }

            Console.WriteLine("Deleting a company");

            _companies.DeleteOnSubmit(nRow);
            _db.SubmitChanges();
        }

        public static void CallProcedure()
        {
            Console.WriteLine("Calling procedure");

            string ownerName = "Куклушева Надежда Антоновна";
            string companyName = String.Empty;
            _db.GetRichestCompany(ownerName, ref companyName);

            Console.WriteLine("Result: " + companyName);
        }
    }
}
