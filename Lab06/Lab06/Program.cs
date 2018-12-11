using System;
using System.Xml;
using System.IO;

namespace Wrox
{
    class consoleApp
    {
        static void Main(string[] args)
        {
            //DoAllAtOnce();

            int menuElement;

            do
            {
                menuElement = ShowMenu();

                if(menuElement != -1 && menuElement != 0)
                    DoJob(menuElement);

            } while (menuElement != 0);
        }

        static void DoAllAtOnce()
        {
            // 1. Открытие документа
            XmlDocument myDocument = new XmlDocument();
            FileStream myFile = new FileStream("../../task.xml", FileMode.Open);
            //FileStream myFile = new FileStream("../../personal_xml.xml, FileMode.Open); 
            myDocument.Load(myFile);

            // 2. а) Получить список всех элементов-потомков по названию тэга
            Console.Write("This Names was found:\r\n");
            XmlNodeList names = myDocument.GetElementsByTagName("Name");
            for (int i = 0; i < names.Count; i++)
                Console.Write(names[i].ChildNodes[0].Value + "\r\n");

            // 2. b) По ID
            Console.Write("\n\nThis passenger has ID=797:\r\n");
            XmlElement id = myDocument.GetElementById("797");
            Console.Write(id.ChildNodes[1].ChildNodes[0].Value + "\r\n");


            // 2. c) Список узлов по запросу XPath
            Console.Write("\n\nSex of survival passengers is:\r\n");
            XmlNodeList sur = myDocument.SelectNodes("//Passenger/Sex/text()[../../Survival/text()='1']");
            for (int i = 0; i < sur.Count; i++)
                Console.Write(sur[i].Value + "\r\n");


            // 2. d) Первый узел по запросу XPath
            Console.Write("\n\nAge of the first survival passenger is:\r\n");
            XmlNode surOne = myDocument.SelectSingleNode("//Passenger/Sex/text()[../../Survival/text()='1']");
            Console.Write(surOne.Value + "\r\n");

            // 3. Доступ к содержимому узлов
            Console.Write("\n\n" + myDocument.DocumentElement.ChildNodes[0].Value + "\r\n");

            Console.Write("\n\nInformation about Doctors: \n");
            XmlNodeList pass = myDocument.GetElementsByTagName("Passenger");
            for (int i = 0; i < pass.Count; i++)
                Console.Write(pass[i].ChildNodes[1].InnerText + " " + pass[i].ChildNodes[4].Value + "\r\n");

            XmlProcessingInstruction myPI = (XmlProcessingInstruction)myDocument.DocumentElement.ChildNodes[0];
            Console.Write("\n\nInstruction: \n Name: " + myPI.Name + "\r\n");
            Console.Write("Data: " + myPI.Data + "\r\n");

            Console.Write("\n\nIDs of Passengers: \n");
            for (int i = 0; i < pass.Count; i++)
                Console.Write(pass[i].ChildNodes[1].InnerText + " : " + pass[i].Attributes[0].Value + "\r\n");

            // 4. Изменения файла

            // 4. a) Удаление содержимого
            XmlElement pcElement = (XmlElement)myDocument.GetElementsByTagName("Age")[1];
            pass[1].RemoveChild(pcElement);
            Console.Write("Delete the first passenge's age..." + "\r\n");
            myDocument.Save("../../task-del.xml");

            // 4. b) Изменение содержимого
            XmlNodeList ageValues = myDocument.SelectNodes("//Passenger/Age/text()");
            for (int i = 0; i < ageValues.Count; i++)
                ageValues[i].Value = ageValues[i].Value + " years old";
            Console.Write("Change format of age..." + "\r\n");
            myDocument.Save("../../task-chg.xml");

            // 4. c) Создание элементов
            XmlElement PassElement = myDocument.CreateElement("Passenger");
            XmlElement SurElement = myDocument.CreateElement("Survival");
            XmlElement NameElement = myDocument.CreateElement("Name");
            XmlElement SexElement = myDocument.CreateElement("Sex");
            XmlElement AgeElement = myDocument.CreateElement("Age");

            XmlText SurText = myDocument.CreateTextNode("1");
            XmlText NameText = myDocument.CreateTextNode("Smith Dr. Brenda");
            XmlText SexText = myDocument.CreateTextNode("female");
            XmlText AgeText = myDocument.CreateTextNode("30");

            // 4. d) Вставка
            SurElement.AppendChild(SurText);
            NameElement.AppendChild(NameText);
            SexElement.AppendChild(SexText);
            AgeElement.AppendChild(AgeText);

            PassElement.AppendChild(SurElement);
            PassElement.AppendChild(NameElement);
            PassElement.AppendChild(SexElement);
            PassElement.AppendChild(AgeElement);

            myDocument.DocumentElement.AppendChild(PassElement);
            myDocument.Save("../../task-new.xml");

            XmlDocument newDocument = new XmlDocument();
            FileStream newFile = new FileStream("../../task-new.xml", FileMode.Open);
            newDocument.Load(newFile);

            XmlElement newElement = (XmlElement)myDocument.GetElementsByTagName("Passenger")[7];
            newElement.SetAttribute("PassengerId", "900");
            myDocument.Save("../../task-attr.xml");

            newFile.Close();
            myFile.Close();

            Console.ReadKey();
        }

        static int ShowMenu()
        {
            int element = -1;

            Console.WriteLine("0. Exit");
            Console.WriteLine("1. GetElementsByTagName");
            Console.WriteLine("2. GetElementsById");
            Console.WriteLine("3. SelectNodes");
            Console.WriteLine("4. SelectSingleNode");
            Console.WriteLine();

            Console.WriteLine("5. Get XmlElement");
            Console.WriteLine("6. Get XmlText");
            Console.WriteLine("7. Get XmlComment");
            Console.WriteLine("8. Get XmlProcessingInstruction");
            Console.WriteLine("9. Get Attributes");
            Console.WriteLine();


            Console.WriteLine("10. Delete");
            Console.WriteLine("11. Changing");
            Console.WriteLine("12. Create");
            Console.WriteLine("13. Insert");
            Console.WriteLine("14. Add attribute");

            Console.Write("Choose element: ");

            try
            {
                element = Int32.Parse(Console.ReadLine());

                if (element < 0 || element > 14)
                    throw new Exception("There is no element with number " + element);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Input can not be empty!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Incorrect input!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return element;
        }

        static void DoJob(int jobIndex)
        {
            XmlDocument myDocument = new XmlDocument();
            FileStream myFile = new FileStream("../../task.xml", FileMode.Open);
            //FileStream myFile = new FileStream("../../personal_xml.xml, FileMode.Open); 
            myDocument.Load(myFile);

            switch (jobIndex)
            {
                case 1:
                    // 2. а) Получить список всех элементов-потомков по названию тэга
                    Console.Write("This Names was found:\r\n");
                    XmlNodeList names = myDocument.GetElementsByTagName("Name");
                    for (int i = 0; i < names.Count; i++)
                        Console.Write(names[i].ChildNodes[0].Value + "\r\n");
                    break;

                case 2:
                    // 2. b) По ID
                    Console.Write("\n\nThis passenger has ID=797:\r\n");
                    XmlElement id = myDocument.GetElementById("797");
                    Console.Write(id.ChildNodes[1].ChildNodes[0].Value + "\r\n");
                    break;

                case 3:
                    // 2. c) Список узлов по запросу XPath
                    Console.Write("\n\nSex of survival passengers is:\r\n");
                    XmlNodeList sur = myDocument.SelectNodes("//Passenger/Sex/text()[../../Survival/text()='1']");
                    for (int i = 0; i < sur.Count; i++)
                        Console.Write(sur[i].Value + "\r\n");
                    break;

                case 4:
                    // 2. d) Первый узел по запросу XPath
                    Console.Write("\n\nAge of the first survival passenger is:\r\n");
                    XmlNode surOne = myDocument.SelectSingleNode("//Passenger/Sex/text()[../../Survival/text()='1']");
                    Console.Write(surOne.Value + "\r\n");
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    // 3. Доступ к содержимому узлов
                    Console.Write("\n\n" + myDocument.DocumentElement.ChildNodes[0].Value + "\r\n");

                    Console.Write("\n\nInformation about Doctors: \n");
                    XmlNodeList pass = myDocument.GetElementsByTagName("Passenger");
                    for (int i = 0; i < pass.Count; i++)
                        Console.Write(pass[i].ChildNodes[1].InnerText + " " + pass[i].ChildNodes[4].Value + "\r\n");

                    XmlProcessingInstruction myPI = (XmlProcessingInstruction)myDocument.DocumentElement.ChildNodes[0];
                    Console.Write("\n\nInstruction: \n Name: " + myPI.Name + "\r\n");
                    Console.Write("Data: " + myPI.Data + "\r\n");

                    Console.Write("\n\nIDs of Passengers: \n");
                    for (int i = 0; i < pass.Count; i++)
                        Console.Write(pass[i].ChildNodes[1].InnerText + " : " + pass[i].Attributes[0].Value + "\r\n");

                    break;
                // 4. Изменения файла

                case 10:
                    XmlNodeList pass10 = myDocument.GetElementsByTagName("Passenger");
                    // 4. a) Удаление содержимого
                    XmlElement pcElement = (XmlElement)myDocument.GetElementsByTagName("Age")[1];
                    pass10[1].RemoveChild(pcElement);
                    Console.Write("Delete the first passenge's age..." + "\r\n");
                    myDocument.Save("../../task-del.xml");
                    break;

                case 11:
                    // 4. b) Изменение содержимого
                    XmlNodeList ageValues = myDocument.SelectNodes("//Passenger/Age/text()");
                    for (int i = 0; i < ageValues.Count; i++)
                        ageValues[i].Value = ageValues[i].Value + " years old";
                    Console.Write("Change format of age..." + "\r\n");
                    myDocument.Save("../../task-chg.xml");
                    break;

                case 12:

                    Console.WriteLine("Creating new elements");
                    // 4. c) Создание элементов
                    XmlElement PassElement = myDocument.CreateElement("Passenger");
                    XmlElement SurElement = myDocument.CreateElement("Survival");
                    XmlElement NameElement = myDocument.CreateElement("Name");
                    XmlElement SexElement = myDocument.CreateElement("Sex");
                    XmlElement AgeElement = myDocument.CreateElement("Age");
                    

                    XmlText SurText = myDocument.CreateTextNode("1");
                    XmlText NameText = myDocument.CreateTextNode("Smith Dr. Brenda");
                    XmlText SexText = myDocument.CreateTextNode("female");
                    XmlText AgeText = myDocument.CreateTextNode("30");

                    // 4. d) Вставка
                    SurElement.AppendChild(SurText);
                    NameElement.AppendChild(NameText);
                    SexElement.AppendChild(SexText);
                    AgeElement.AppendChild(AgeText);

                    PassElement.AppendChild(SurElement);
                    PassElement.AppendChild(NameElement);
                    PassElement.AppendChild(SexElement);
                    PassElement.AppendChild(AgeElement);

                    myDocument.DocumentElement.AppendChild(PassElement);
                    myDocument.Save("../../task-new.xml");

                    /*XmlDocument newDocument = new XmlDocument();
                    FileStream newFile = new FileStream("../../task-new.xml", FileMode.Open);
                    newDocument.Load(newFile);
                    newFile.Close();*/
                    break;

                case 13:
                case 14:
                    Console.WriteLine("Inserting attribute");
                    myDocument = new XmlDocument();
                    if(myFile != null)
                        myFile.Close();

                    myFile = new FileStream("../../task.xml", FileMode.Open);
                    //FileStream myFile = new FileStream("../../personal_xml.xml, FileMode.Open); 
                    myDocument.Load(myFile);

                    XmlNodeList list = myDocument.GetElementsByTagName("Passenger");

                    XmlElement newElement = (XmlElement)list[6];
                    newElement.SetAttribute("PassengerId", "900");
                    myDocument.Save("../../task-attr.xml");
                    break;
            }

            
            myFile.Close();

            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
