using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_exceptions
{
    class MatrixExceptionSize : Exception
    {
        public MatrixExceptionSize(Matrix a, Matrix b)
        {
            Na = a.Na;
            STa = a.STa;
            Nb = b.Nb;
            STb = b.STb;
        }

        private int Na;
        private int STa;
        private int Nb;
        private int STb;

        private string exinfo
        {
            get
            {
                return $"Ошибка!!! Не совпадают размерности матриц! ";
            }
        }

        private void PrintInfo()
        {
            Console.WriteLine(exinfo);
        }
    }
}
