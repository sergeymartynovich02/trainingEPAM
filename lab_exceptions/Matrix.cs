using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_exceptions
{
    class Matrix
    {
        // Скрытые поля
        private int nA;
        private int stlbA;
        private int nB;
        private int stlbB;
        private int[,] massA;
        private int[,] massB;

        // Создаем конструкторы матрицы
        public Matrix() { }
        public int Na
        {
            get { return nA; }
            set { if (value > 0) nA = value; }
        }
        public int STa
        {
            get { return stlbA; }
            set { if (value > 0) stlbA = value; }
        }
        public int Nb
        {
            get { return nB; }
            set { if (value > 0) nB = value; }
        }
        public int STb
        {
            get { return stlbB; }
            set { if (value > 0) stlbB = value; }
        }

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int na, int stlba, int nb, int stlbb)
        {
            this.nA = nA;
            this.stlbA = stlbA;
            massA = new int[this.nA, this.stlbA];
            this.nB = nB;
            this.stlbB = stlbB;
            massB = new int[this.nB, this.stlbB];
        }
        public int this[int i, int j]
        {
            get
            {
                return massA[i, j];
                return massB[i, j];
            }
            set
            {
                massA[i, j] = value;
                massB[i, j] = value;
            }
        }

        // Умножение матрицы А на матрицу В
        public static Matrix umn(Matrix a, Matrix b)
        {
            if(a.Na != b.STb)
            {
                throw new MatrixExceptionSize(a, b);
            }
            Matrix resMass = new Matrix(a.Na, a.STa, b.Nb, b.STb);
                for (int i = 0; i < a.Na; i++)
                    for (int j = 0; j < b.STb; j++)
                        for (int k = 0; k < b.Nb; k++)
                            resMass[i, j] += a[i, k] * b[k, j];
                return resMass;
        }

        // Перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.umn(a, b);
        }


        // Метод вычитания одной матрицы из другой
        public static Matrix razn(Matrix a, Matrix b)
        {
            if (a.Na != a.STa || b.Nb != b.STb || b.Nb != b.STb || a.Na != b.Nb || a.STa != b.STb)
            {
                throw new MatrixExceptionSize(a, b);
            }
            Matrix resMass = new Matrix(a.Na, a.STa, b.Nb, b.STb);
            for (int i = 0; i < a.Na; i++)
            {
                for (int j = 0; j < b.STb; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }

        // Метод, который возвращает нулевую матрицу
        public void GetEmpty(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.Na, a.STa, b.Nb, b.STb);
            for (int i = 0; i < a.Na; i++)
            {
                for (int j = 0; j < a.STa; j++)
                {
                    resMass[i, j] = 0;
                }
            }
        }


        // Метод сложения матрицы
        public static Matrix Sum(Matrix a, Matrix b)
        {
            if (a.Na != a.STa || b.Nb != b.STb || a.Na != b.Nb || a.STa != b.STb)
            {
                throw new MatrixExceptionSize(a, b);
            }
            Matrix resMass = new Matrix(a.Na, a.STa, b.Nb, b.STb);
            for (int i = 0; i < a.Na; i++)
            {
                for (int j = 0; j < b.STb; j++)
                {

                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }

        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }

    }
}
