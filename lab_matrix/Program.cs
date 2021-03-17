using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader infile = new StreamReader("Inlet.txt");
            StreamWriter outfile = new StreamWriter("Outlet.txt");

            char[] разделители = { ' ' };
            string[] mas = infile.ReadLine().Split(разделители, StringSplitOptions.RemoveEmptyEntries);

            int N = int.Parse(mas[0]);
            int G = int.Parse(mas[1]);
            int prG = int.Parse(mas[2]);
            int Cel = 0;
            int temp = 0;
            int[,] matrix = new int[N, N];

            Cel = (N / 2);

            if (N % 2 == 0)
            {
                matrix[(Cel), (Cel)] = G;
                matrix[(Cel), (Cel - 1)] = G;
                matrix[(Cel - 1), (Cel)] = G;
                matrix[(Cel - 1), (Cel- 1)] = G;
            }
            else
            {
                matrix[Cel, Cel] = G;
            }

            temp = G;

            if(N%2==0)
            {
                for (int i = Cel + 1; i < N; i++)
                {
                    matrix[Cel, i] = temp + prG;
                    matrix[i, Cel - 1] = temp + prG;
                    matrix[i, Cel] = temp + prG;
                    matrix[Cel - 1, i] = temp + prG;
                    temp += prG;
                }
                temp = G;


                for (int i = Cel-2; i >= 0; i--)
                {
                    matrix[i, Cel] = temp + prG;
                    matrix[Cel - 1, i] = temp + prG;
                    matrix[Cel, i] = temp + prG;
                    matrix[i, Cel - 1] = temp + prG;
                    temp += prG;
                }
                temp = G;


                for (int i = Cel+1; i < N; i++)
                {
                    matrix[i, N - 1 - i] = temp + prG;
                    matrix[i, i] = temp + prG;
                    temp += prG;
                }
                temp = G;

                for (int i = Cel-2; i >= 0; i--)
                {
                    matrix[i, i] = temp + prG;
                    matrix[i, N - 1 - i] = temp + prG;
                    temp += prG;
                }
                temp = G;

                for(int i = 0; i<N; i++)
                {
                    matrix[i, 0] = matrix[0, N - 1];
                    matrix[i, N-1] = matrix[0, N - 1];
                    matrix[0, i] = matrix[0, N - 1];
                    matrix[N-1, i] = matrix[0, N - 1];
                }

            }
            else 
            {
                for (int i = Cel + 1; i < N; i++)
                {
                    matrix[Cel, i] = temp + prG;
                    matrix[i, Cel] = temp + prG;
                    temp += prG;
                }
                temp = G;

                for (int i = Cel - 1; i >= 0; i--)
                {
                    matrix[i, Cel] = temp + prG;
                    matrix[Cel, i] = temp + prG;
                    temp += prG;
                }
                temp = G;

                for (int i = Cel + 1; i < N; i++)
                {
                    matrix[i, N - 1 - i] = temp + prG;
                    matrix[i, i] = temp + prG;
                    temp += prG;
                }
                temp = G;

                for (int i = Cel - 1; i >= 0; i--)
                {
                    matrix[i, i] = temp + prG;
                    matrix[i, N - 1 - i] = temp + prG;
                    temp += prG;
                }
                temp = G;





            }


            for (int i = 0; i < (N); i++)
            {
                for (int j = 0; j < (N); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();

            for (int i = 0; i < (N); i++)
            {
                for (int j = 0; j < (N); j++)
                {
                    outfile.Write("{0} ", matrix[i, j]);
                }
                outfile.WriteLine();
            }
            outfile.Close();
        }
    }
}
