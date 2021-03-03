using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2_2
{
    class Program
    {
        static int Perevod(int x)
        {
            return x < 2 ? x % 2 : (x % 2) + 10 * Perevod(x / 2);
        }
        static void Main(string[] args)
        {
            Console.Write("Введите десятичное число: ");
            int x = int.Parse(Console.ReadLine());
            int Perevod1 = Perevod(x);

            if (x >= 0)
            {
                Console.Write("В двоичной системе счисления это: ");
                Console.WriteLine(Perevod1);


            }
            else
            {
                Console.WriteLine("Такой формат числа недопустим! ");

            }
            Console.ReadKey();
        }
    }
}
