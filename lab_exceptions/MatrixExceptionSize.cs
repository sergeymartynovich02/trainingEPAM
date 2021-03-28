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
            N = a.N;
            ST = b.ST;
        }

        private int N;
        private int ST;

        private string exinfo
        {
            get
            {
                return $"Умножение матриц невозможно, потому что: \nЧисло столбцов матрицы А " +
                    $"({N}) не совпадает с числом строк матрицы В ({ST})";
            }
        }

        private void PrintInfo()
        {
            Console.WriteLine(exinfo);
        }
    }
}
