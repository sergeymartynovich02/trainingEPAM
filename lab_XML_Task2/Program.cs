using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

/*
    Дан XML - документ, содержащий хотя бы один атрибут. Найти и вывести имена атрибутов,
    а также все связанные с ними значения (все значения считаются текстовыми).
    Порядок имен должен соответствовать порядку их первого вхождения в документ; 
    значения, связанные с каждым именем, выводить в алфавитном порядке.
*/

namespace Lab_XML_Task2
{
    class Program
    {
        static void Main()
        {
            XDocument xDoc = XDocument.Load("XmlFile.xml");

            Console.WriteLine("ИЗНАЧАЛЬНЫЙ XML ФАЙЛ: \n\n" + xDoc + "\n\n");


            var res = xDoc.Element("Root")
                            .Elements()
                            .OrderBy(c => (string)c.Attribute("Attribute1"));

            XDocument doc = new XDocument(new XElement("Root", res));


            Console.WriteLine("КОНЕЧНЫЙ XML ФАЙЛ: \n\n" + doc + "\n\n");



            doc.Save("file1.xml");
            XmlDocument xDoc1 = new XmlDocument();
            xDoc1.Load(Path.GetFullPath("file1.xml"));
            XmlElement xRoot = xDoc1.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Attribute1");
                    if (attr != null)
                        Console.WriteLine("Имя атрибута: " + attr.Name + " ==> Значение: " + attr.InnerText);
                }

            }
            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}