using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1_epam
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            string BinaryCode;
            Console.WriteLine("Введите число: ");
            number = Convert.ToInt32(Console.ReadLine());
            BinaryCode = Convert.ToString(number, 2);
            Console.WriteLine("Ваше число в двоичной системе исчисления^");
            Console.WriteLine(BinaryCode);
            Console.ReadKey();
        }
    }
}
