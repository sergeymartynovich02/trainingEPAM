using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_exceptions
{
    class MainProgram
    {

        static void Main()
        {
            try { 

                Console.WriteLine("Введите кол-во строк матрицы: ");
                int nn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите кол-во столбцов матрицы: ");
                int stlbc = Convert.ToInt32(Console.ReadLine());

                string answer = "";
                int temp1 = 0;
                int temp2 = 0;

                // Инициализация матрицы
                Matrix mass1 = new Matrix(nn, stlbc);
                Matrix mass2 = new Matrix(nn, stlbc);
                Matrix mass3 = new Matrix(nn, stlbc);
                Matrix mass4 = new Matrix(nn, stlbc);
                Matrix mass5 = new Matrix(nn, stlbc);
                Matrix mass6 = new Matrix(nn, stlbc);

                // Проверка надобности применения метода GetEmpy()
                Console.WriteLine("Матрица А должна быть нулевой? y(да)/n(нет) ");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "y")
                {
                    mass1.GetEmpty(mass1);
                    temp1 = 1;

                }
                else if (answer == "n")
                {
                    //Ввод с клавиатуры матрицы А
                    Console.WriteLine("Введите матрицу А по одному элементу через ENTER: ");
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                            mass1[i, j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    temp1 = 0;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный символ, попробуйте снова ");
                    Main();
                }
                answer = null;


                // Проверка надобности применения метода GetEmpy()
                Console.WriteLine("Матрица B должна быть нулевой? y(да)/n(нет) ");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "y")
                {
                    mass1.GetEmpty(mass1);
                    temp2 = 1;
                }
                else if (answer == "n")
                {
                    //Ввод с клавиатуры матрицы B
                    Console.WriteLine("Введите матрицу B по одному элементу через ENTER: ");
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                            mass2[i, j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    temp2 = 0;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный символ, попробуйте снова ");
                    Main();
                }

                if (temp1 == 1 && temp2 == 1)
                {
                    Console.WriteLine("Рассчёты бессмыслены, так как обе матрицы нулевые. \nИ в итоге каждого из них результат будет один и тот же. \nА именно нулевая матрица:  ");
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass1[i, j] + "\t");
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                }

                else
                {
                    //Вывод на экран матрицы А
                    Console.WriteLine("Матрица А: ");
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass1[i, j] + "\t");
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine();

                    //Вывод на экран матрицы B
                    Console.WriteLine("Матрица В: ");
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass2[i, j] + "\t");
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine();

                    //Вывод на экран суммы матриц А и B
                    Console.WriteLine("Сумма матриц А и B: ");
                    mass3 = (mass1 + mass2);
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass3[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    //Вывод на экран разности матриц A и B (A-B)
                    Console.WriteLine("Разность матриц А и B (Матрица А - Матрица В): ");
                    mass4 = (mass1 - mass2);
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass4[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    //Вывод на экран разности матриц B и A (B-A)
                    Console.WriteLine("Разность матриц B и A (Матрица В - Матрица А): ");
                    mass5 = (mass2 - mass1);
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass5[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();


                
                    //Вывод на экран произведения матриц A и B
                    Console.WriteLine("Произведение матриц A и B: ");
                    mass6 = (mass1 * mass2);
                    for (int i = 0; i < nn; i++)
                    {
                        for (int j = 0; j < stlbc; j++)
                        {
                            Console.Write(mass6[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                }
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Вы допустили следующую ошибку при вводе: " + ex.Message + "\nПовторите попытку снова. \n" );
                Main();
            }
        }
    }
}
