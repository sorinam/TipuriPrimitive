using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Goats
    {
        public float CalculateCant(int Xdays, int Ygoats, float Zkg, int Wdays, int Qgoats)
        {
            float result;
            result = Zkg / Xdays/Ygoats*Qgoats*Wdays;
            return result;
        }
    }
}
