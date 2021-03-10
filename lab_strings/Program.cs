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
            StreamReader infile = new StreamReader(@"D:\git\lab_strings\Inlet.txt");

            string arr = infile.ReadLine();
            int length = arr.Length;
            char[] temp = new char[length];

            int j = 0, k = 1;
            for (int i = length - 1; i >= length / 2; i--)
            {
                temp[j] = arr[i];
                j += 2;
            }
            for (int l = 0; l < (length / 2); l++)
            {
                temp[k] = arr[l];
                k += 2;
            }

            StreamWriter outfile = new StreamWriter(@"D:\git\lab_strings\Outlet.txt");

            outfile.WriteLine(temp);
            outfile.Close();
        }
    }
}
