using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Interaces
{
    class ProgramHelper : ProgramConverter, ICodeChecker
    {

        public bool CheckCodeSyntax(string CodeString, string UsedLang)
        {
            if (UsedLang == "C#")
            {
                if (CodeString[CodeString.Length - 1] == ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (UsedLang == "VB")
            {
                if (CodeString[CodeString.Length - 1] != ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            { 
                return false;
            }
        }
    }
}
