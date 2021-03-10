using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, eps;
            Console.WriteLine("Введите начальное значение а отрезка [a,b]:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите конечное значение b отрезка [a,b]:");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите точность eps:");
            eps = Convert.ToDouble(Console.ReadLine());

            double approximatione = fInitialapproximationе(a, b);
            double c = fFixedpoint(a, b);
            double x0;
            int k = 0;
            do
            {
                k++;
                x0 = approximatione;
                approximatione = x0 - ((f(x0) * (x0 - c)) / (f(x0) - f(c)));
            }
            while (Math.Abs(x0 - approximatione) > eps);
            Console.WriteLine($"Приближение равно {approximatione} в результате {k} итераций:");
            Console.ReadKey();

        }
        static double f(double x)
        {
            return 5 * x - 8 * Math.Log(x) - 8;
        }
        static double fDerivative(double x)
        {
            return 5 - (8 / x);
        }
        static double fSecondDerivative(double x)
        {
            return 8 / (Math.Pow(x, 2));
        }
        static double fInitialapproximationе(double a, double b)
        {
            return f(a) * fSecondDerivative(a) > 0 ? b : a;
        }

        static double fFixedpoint(double a, double b)
        {
            return f(a) * fSecondDerivative(a) > 0 ? a : b;
        }

    }
}
