using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/*
    Даны имена существующего текстового файла и создаваемого XML-документа.
    Каждая строка текстового файла содержит несколько (одно или более) слов, разделенных ровно одним пробелом.
    Создать XML-документ с корневым элементом root, элементами первого уровня line и элементами второго уровня word.
    Элементы line соответствуют строкам исходного файла и не содержат дочерних текстовых узлов,
    элементы word каждого элемента line содержат по одному слову из соответствующей строки 
    (слова располагаются в порядке их следования в исходной строке). 
    Элемент line должен содержать атрибут num, равный порядковому номеру строки в исходном файле,
    элемент word должен содержать атрибут num, равный порядковому номеру слова в строке. 
*/


namespace lab_XML_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument();
            XElement root = new XElement("root");

            StreamReader fileIn = new StreamReader("file.txt");
            string str; int[] nums = { 0, 0 };

            while ((str = fileIn.ReadLine()) != null)
            {
                XElement line = new XElement("line");
                XAttribute num1 = new XAttribute("num", nums[0].ToString());
                line.Add(num1);

                string[] s1 = str.Trim().Split(); nums[1] = 0;
                foreach (string s in s1)
                {
                    XElement word = new XElement("word");
                    XAttribute num2 = new XAttribute("num", nums[1].ToString());
                    XText text = new XText(s);
                    word.Add(num2);
                    word.Add(text);
                    line.Add(word);
                    nums[1]++;
                }
                root.Add(line);
                nums[0]++;
            }
            fileIn.Close();
            xdoc.Add(root);
            xdoc.Save("xmlFile");
            Console.WriteLine(xdoc + "\n");
            Console.ReadKey();
            
        }
    }
}
