using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Interaces
{
    class ProgramConverter : IConvertible
    {
        public string ConvertToSharp(string VBText)
        {
            return "Конвертирование в C# выполнено успешно!";
        }

        public string ConvertToVB(string CSText)
        {
            return "Конвертирование в VB выполнено успешно!";
        }
    }

}
