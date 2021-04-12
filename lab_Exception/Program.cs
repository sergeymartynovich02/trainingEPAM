using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Exception
{
    static class MatrixGetRowsColumns
    {

        // получение количества строк матрицы
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetLength(0);
        }

        //  получение количества столбцов матрицы
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetLength(1);
        }

    }
    class Matrix
    {
        // Метод для получения матрицы из консоли
        static int[,] GetMatrixFromConsole(string name)
        {
            Console.Write("Введите количество строк матрицы {0}:    ", name);
            var r = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы {0}: ", name);
            var c = int.Parse(Console.ReadLine());


            var matrix = new int[r, c];



            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        // Метод для вывода матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        // Метод для сложения двух матриц
        static int[,] MatrixSum(int[,] matrixA, int[,] matrixB)
        {

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    try
                    {
                        matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new Exception("Операция невозможна! Размерности матриц не совпадают.");
                        return matrixA;
                    }
                }
            }

            return matrixC;
        }

        // Метод для вычитания двух матриц
        static int[,] MatrixSubstract(int[,] matrixA, int[,] matrixB)
        {

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    try
                    {
                        matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                    }

                    catch (IndexOutOfRangeException)
                    {
                        throw new Exception("Операция невозможна! Размерности матриц не совпадают.");
                        return matrixA;
                    }


                }
            }

            return matrixC;
        }

        // Метод для умножения матриц
        static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        try
                        {
                            matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            throw new Exception("Операция невозможна! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                            return matrixA;
                        }
                    }
                }
            }

            return matrixC;
        }


        // Метод GetEmpty, который возвращает нулевую матрицу
        static int[,] MatrixGetEmpty(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    try
                    {
                        matrixC[i, j] = 0;
                    }
                    catch (IndexOutOfRangeException)
                    {

                        throw new Exception("Операция невозможна! Размерности матриц не совпадают.");
                        return matrixA;
                    }

                }
            }

            return matrixC;
        }

        static void Main(string[] args)
        {
            var a = GetMatrixFromConsole("A");
            var b = GetMatrixFromConsole("B");


            Console.WriteLine("Матрица A:");
            PrintMatrix(a);

            Console.WriteLine("Матрица B:");
            PrintMatrix(b);

            //// Результат сложения матриц
            var resultSum = MatrixSum(a, b);
            Console.WriteLine("Сумма матриц:");
            PrintMatrix(resultSum);

            //// Результат произведения матриц
            var resultMultiplication = MatrixMultiplication(a, b);
            Console.WriteLine("Произведение матриц:");
            PrintMatrix(resultMultiplication);

            //// Разность матриц
            var resultSubstract = MatrixSubstract(a, b);
            Console.WriteLine("Разность матриц: ");
            PrintMatrix(resultSubstract);

            //// Метод GetEmpty
            var resultMatrixGetEmpty = MatrixGetEmpty(a, b);
            Console.WriteLine("Нулевая матрица: ");
            PrintMatrix(resultMatrixGetEmpty);

            Console.ReadLine();
        }
    }
}
