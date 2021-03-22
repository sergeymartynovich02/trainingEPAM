using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_strings
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader infile = new StreamReader("Inlet.txt");
            StreamWriter outfile = new StreamWriter("Outlet.txt");


            string arr = infile.ReadToEnd();
            String[] words = arr.Split('\n', '\r', ' ');
            int lastEl = words.Length;

            for (int s = 0; s < lastEl; s++)
            {
                string tempStr = words[s];
                int length = tempStr.Length;
                char[] temp = new char[length];

                int j = 0, k = 1;
                for (int i = length - 1; i >= length / 2; i--)
                {
                    temp[j] = tempStr[i];
                    j += 2;
                }
                for (int l = 0; l < (length / 2); l++)
                {
                    temp[k] = tempStr[l];
                    k += 2;
                }

                outfile.WriteLine(temp);
            }

            outfile.Close();
        }

    }
}
