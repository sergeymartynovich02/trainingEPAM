using System;

namespace lab_overload
{
    class Vector
    {
        private int x;
        private int y;
        private int z;


        public Vector(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public int Z
        {
            get
            {
                return z;
            }
        }


        public static Vector operator +(Vector V1, Vector V2)
        {
            return new Vector(V1.X + V2.X, V1.Y + V2.Y, V1.Z + V2.Z);
        }

        public static Vector operator *(Vector V1, Vector V2)
        {
            return new Vector(V1.X * V2.X, V1.Y * V2.Y, V1.Z * V2.Z);
        }

        public static Vector operator -(Vector V1, Vector V2)
        {
            return new Vector(V1.X - V2.X, V1.Y - V2.Y, V1.Z - V2.Z);
        }

        public static Vector operator *(Vector V1, int scalar)
        {
            return new Vector(V1.X * scalar, V1.Y * scalar, V1.Z * scalar);
        }

        public static int ScalarProduct(Vector V1, Vector V2)
        {
            return  (V1.X * V2.X + V1.Y * V2.Y + V1.Z * V2.Z);
        }

        public static int VectorProduct(Vector V1, Vector V2)
        {
            return  ((V1.Y * V2.Z - V1.Z * V2.Y) - (V1.X * V2.Z - V1.Z * V2.X) + (V1.X * V2.Y - V1.Y * V2.X));
        }

        public static double ModulVector(Vector V1)
        {
            return (Math.Sqrt(V1.X * V1.X + V1.Y * V1.Y + V1.Z * V1.Z));
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

    }

    class VectorDemo
    {
        static void Main(string[] args)
        {
            int x0, y0, z0, x1, y1, z1;

            Console.WriteLine("Введите координаты первого вектора x0 y0 z0 через пробел: ");
            string textV1 = Console.ReadLine();
            string[] numbers1 = textV1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x0 = Convert.ToInt32(numbers1[0]);
            y0 = Convert.ToInt32(numbers1[1]);
            z0 = Convert.ToInt32(numbers1[2]);

            Console.WriteLine("Введите координаты второго вектора x1 y1 z1 через пробел: ");
            string textV2 = Console.ReadLine();
            string[] numbers2 = textV2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x1 = Convert.ToInt32(numbers2[0]);
            y1 = Convert.ToInt32(numbers2[1]);
            z1 = Convert.ToInt32(numbers2[2]);

            Console.WriteLine("Введите скаляр (одно число): ");
            int scale = Convert.ToInt32(Console.ReadLine());

            Vector v0 = new Vector(x0, y0, z0);
            Vector v1 = new Vector(x1, y1, z1);
            Vector SumVectors = v0 + v1;
            Vector Substraction = v0 - v1;
            Vector ScalarProduct1 = v0 * scale;
            Vector ScalarProduct2 = v1 * scale;
            int VectorProduct = Vector.VectorProduct(v0, v1);
            int ScalarProductVectors = Vector.ScalarProduct(v0, v1);
            double ModulVector1 = Vector.ModulVector(v0);
            double ModulVector2 = Vector.ModulVector(v1);
            Console.WriteLine("Первый исходный вектор: " + v0 +
                               "\nВторой исходный вектор: " + v1 +
                               "\nСумма этих векторов: " + SumVectors +
                               "\nРазность этих векторов: " + Substraction +
                               "\nПервый вектор умноженный на скаляр: " + ScalarProduct1 +
                               "\nВторой вектор умноженный на скаляр: " + ScalarProduct2 +
                               "\nСкалярное произведение векторов: " + ScalarProductVectors +
                               "\nВекторное произведение векторов: " + VectorProduct +
                               "\nМодуль первого вектора: " + ModulVector1 +
                               "\nМодуль второго вектора: " + ModulVector2);
            Console.ReadKey();
        }
    }
}
