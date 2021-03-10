using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_epam
{
    class Program
    {
        static void Main(string[] args)
        {
            double n, A, eps;
            Console.WriteLine("Введите значения A, n и eps: ");
            A = Convert.ToDouble(Console.ReadLine());
            n = Convert.ToDouble(Console.ReadLine());
            eps = Convert.ToDouble(Console.ReadLine());
            var x0 = A / n;
            var x1 = (1 / n) * ((n - 1) * x0 + A / Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Pow(x0, (int)n - 1));
            }



            Console.WriteLine("Результат с помощью метода Ньютона: ");
            Console.WriteLine(x1);
            Console.WriteLine("Результат с помощью метода Math.Pow: ");
            double res = (Math.Pow(A, 1/n));
            Console.WriteLine(res);
            Console.ReadKey();
        }

        static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }
    }
}
