using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, eps;
            Console.WriteLine("Введите х, который по модулю больше единицы");
            x = Convert.ToDouble(Console.ReadLine());
            if (Math.Abs(x)<1)
            {
                Console.WriteLine("Вы ввели неверный х");
            }
            else
                Console.WriteLine("Введите точность eps");

            eps = Convert.ToDouble(Console.ReadLine());
            double term = (1/x);
            double result = 0;
            int n = 0;
            while ((1/(2 * n + 1)) * term > eps)
            {
               result += (1/(2 * n + 1)) * term;
               term *= 1 / Math.Pow(x,(2 * n + 1));
               n++;
            }
            Console.WriteLine("Значение суммы");
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
