using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_class
{
    abstract class Figure
    {
        public abstract string Area();
        public abstract string Perimeter();
        public abstract string FigureName();

        public void Output()
        {
            Console.WriteLine(
            $"\nЕсли Вы ввели отрицательное значение сторон или высоты, то это значение будет заменено на положительное\n\n" +
            $"Название фигуры: {FigureName()}\n" +
            $"Площадь: {Area()}\n" +
            $"Периметр: {Perimeter()}"
            );
            Console.WriteLine();
        }
    }

    class Paralelogram : Figure
    {
        double sideA;
        double sideB;
        double height;
        public Paralelogram(double parSideA, double parSideB, double parHeight)
        {
            sideA = parSideA;
            sideB = parSideB;
            height = parHeight;
        }
        public double SideA
        {
            get { return sideA; }
            set { sideA = value < 0 ? -value : value; }
        }
        public double SideB
        {
            get { return sideB; }
            set { sideB = value < 0 ? -value : value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value < 0 ? -value : value; }
        }

        public override string Area()
        {
            return (sideA * height).ToString();

        }

        public override string Perimeter()
        {
            return ((sideA + sideB) * 2).ToString();
        }
        public override string FigureName()
        {
            return "Параллелограмм";
        }
    }
    class Program
    {
        static void Main()
        {
            Figure figure1 = new Paralelogram(10, 5, 9);
            figure1.Output();
            Console.ReadKey();
        }
    }
}
