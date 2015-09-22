using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class CalcBirdDistance
    {public float CalculateBirdDistance(int D, int X)
        {
            float result=0 ;
            if ((D==0)||(X==0))
                    {//invalid data
                result = -1;
            }
            return result;
        }
    }
}
