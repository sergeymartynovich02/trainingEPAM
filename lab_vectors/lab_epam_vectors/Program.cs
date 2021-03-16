using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_epam_vectors
{
    class Program
    {
        static void Main(string[] args)
        {


            StreamReader infile = new StreamReader("Inlet.txt");
            StreamWriter outfile = new StreamWriter("Outlet.txt");
            char[] разделители = { ' ' }; 
            string[] mas = infile.ReadLine().Split(разделители, StringSplitOptions.RemoveEmptyEntries);
            string str = "";
            string output = "";



            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (int.Parse(mas[j]) < int.Parse(mas[min]))
                    {
                        min = j;
                    }
                }
                var temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }



            for (int i = 0; i < mas.Length; i++)
            {
                str += " " + mas[i];
            }
            str = str.Trim();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                output += str[i];
            }
            outfile.Write(output);
            outfile.Close();
        }
    }
}
