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
        private int n;
        private int stlb;
        private int[,] mass;

        // Создаем конструкторы матрицы
        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public int ST
        {
            get { return stlb; }
            set { if (value > 0) n = value; }
        }

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int n, int stlb)
        {
            this.n = n;
            this.stlb = stlb;
            mass = new int[this.n, this.stlb];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        // Умножение матрицы А на матрицу В
        public static Matrix umn(Matrix a, Matrix b)
        {
            if(a.N != b.ST)
            {
                throw new MatrixExceptionSize(a, b);
            }
            Matrix resMass = new Matrix(a.N, a.ST);
                for (int i = 0; i < a.N; i++)
                    for (int j = 0; j < b.ST; j++)
                        for (int k = 0; k < b.N; k++)
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
            Matrix resMass = new Matrix(a.N, b.ST);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.ST; j++)
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
        public void GetEmpty(Matrix a)
        {
            Matrix resMass = new Matrix(a.N, a.ST);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.ST; j++)
                {
                    resMass[i, j] = 0;
                }
            }
        }


        // Метод сложения матрицы
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N, a.ST);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.ST; j++)
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
