using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQLab
{
    static class LinqToXml
    {
        public const string PathToSourceXml = "../../../xml.xml";

        public const string PathToUpdatedXml = "../../../xml_update.xml";

        public const string PathToWrittenXml = "../../../xml_add.xml";
        public static void ReadFromXml()
        {
            // Чтение файла и вывод в консоль
            XDocument xdoc = XDocument.Load(PathToSourceXml);

            foreach(XElement row in xdoc.Element("root").Elements("row"))
            {
                XAttribute id = row.Attribute("Id");
                XAttribute name = row.Attribute("CompanyName");
                XAttribute phone = row.Attribute("PhoneNumber");

                Console.WriteLine("Id: {0}, Name: {1}, Phone: {2}", id.Value, name.Value, phone.Value);
            }
        }

        public static void UpdateXml()
        {
            // Сменить имя 10ой компании на "UNNAMED"
            XDocument xdoc = XDocument.Load(PathToSourceXml);

            foreach (XElement row in xdoc.Element("root").Elements("row"))
            {
                XAttribute id = row.Attribute("Id");
                XAttribute name = row.Attribute("CompanyName");
               
                if(id.Value == "10")
                {
                    name.Value = "UNNAMED";
                }
            }

            xdoc.Save(PathToUpdatedXml);
        }

        public static void AddToXml()
        {
            // Чтение файла и вывод в консоль
            XDocument xdoc = XDocument.Load(PathToSourceXml);

            XElement root = xdoc.Element("root");

            XElement nRow = new XElement("NEW_ELEMENT");
            XAttribute id = new XAttribute("id", "9999");
            XAttribute test = new XAttribute("TEST", "TEST");
            XElement child = new XElement("CHILD");
            XAttribute childAttribute = new XAttribute("childAttr", "Value");

            child.Add(childAttribute);
            nRow.Add(id);
            nRow.Add(test);
            nRow.Add(child);

            root.Add(nRow);
            xdoc.Save(PathToWrittenXml);
        }
    }
}
