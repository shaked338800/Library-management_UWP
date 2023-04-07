using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryMvvm.Interfaces
{
    internal class IvalidationImplementation : Ivalidation     
    {
        public void ValidInputNumbers(double parameter) 
        {
            if (parameter == 0)
                throw new Exception();
        }
        public void ValidInputString(string parameter, string serial) 
        {
            if (serial.Length != 13)
                throw new Exception();

            if (string.IsNullOrEmpty(parameter))
                throw new Exception();
        }
        public void ValidIsCheck(bool[] boolAray)  
        {
            foreach (var cell in boolAray)
            {
                if (cell == true)
                    return;
            }
            throw new Exception();
        }
    }
}
