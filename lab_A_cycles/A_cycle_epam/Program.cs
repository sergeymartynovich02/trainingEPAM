using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_cycle_epam
{
    class Program
    {
        static long Fact(long value)
        {
            return (value == 0) ? 1 : value * Fact(value - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите k");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите x");
            double x = double.Parse(Console.ReadLine());
            double s = 0;

            for (int n = 0; n <= k; n++)
                s += Math.Pow(-1, n) *((Math.Pow(x, 4 * n + 1)) / ((Fact(2 * n)) * (4 * n + 1)));

            Console.WriteLine("Результат = {0}", s.ToString());
            Console.ReadKey();
        }
    }
}