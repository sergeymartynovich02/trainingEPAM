﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Interfaces
{
    public interface IConvertible
    {
        string ConvertToSharp(string StrVBCode);
        string ConvertToVB(string StrCSCode);
    }
}
