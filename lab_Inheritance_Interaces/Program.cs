using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Interaces
{
    class Program
    {
        static void Main()
        {
            ProgramHelper[] El_1 = new ProgramHelper[1];
            ProgramConverter[] El_2 = new ProgramConverter[1];
            string CodeStr, Language;
            Console.Write("Введите строку кода, которую хотите преобразовать: ");
            CodeStr = Console.ReadLine();
            Console.Write("Введите язык программирования, на котором написана эта строка: ");
            Language = Console.ReadLine();
            Console.WriteLine("ProgramHelper:");
            for (int i = 0; i < El_1.Length; i++)
            {
                El_1[i] = new ProgramHelper();
                if (El_1[i] is ICodeChecker)
                {
                    if (El_1[i].CheckCodeSyntax(CodeStr, Language))
                    {
                        if (Language == "C#")
                        {
                            Console.WriteLine(El_1[i].ConvertToVB(CodeStr));
                        }
                        else if (Language == "VB")
                        {
                            Console.WriteLine(El_1[i].ConvertToSharp(CodeStr));
                        }
                    }
                }
                else
                {
                    Console.WriteLine(El_1[i].ConvertToSharp(CodeStr));
                    Console.WriteLine(El_1[i].ConvertToVB(CodeStr));
                }
            }
            Console.WriteLine("ProgramConverter:");
            for (int i = 0; i < El_2.Length; i++)
            {
                El_2[i] = new ProgramConverter();
                if (!(El_2[i] is ICodeChecker))
                {
                    if (Language == "C#")
                    {
                        Console.WriteLine(El_2[i].ConvertToVB(CodeStr));
                    }
                    else if (Language == "VB")
                    {
                        Console.WriteLine(El_2[i].ConvertToSharp(CodeStr));
                    }
                }
                else
                {
                    Console.WriteLine(El_2[i].ConvertToSharp(CodeStr));
                    Console.WriteLine(El_2[i].ConvertToVB(CodeStr));
                }
            }
            Console.ReadKey();
        }
    }
}

