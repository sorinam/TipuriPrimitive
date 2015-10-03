using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Pepene
    {
        public string Verify_Kg(int i)
        {
            string result = "";
            if (i % 2 == 0 && i>2)
                result = "DA";
            else
                result = "NU";
            return result;
        }
    }
}
