using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryMvvm.Interfaces
{
    internal interface Ivalidation
    {
        void ValidIsCheck(bool[] boolAray); //חתימות וולידאציה שבודקות בעצם שהקלט מהמשתמש עומד בדרישות הרצויות
        void ValidInputString(string parameter,string serial);
        void ValidInputNumbers(double parameter);
    }
}
