using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class CalcBirdDistance
    {public float CalculateBirdDistance(float D, float X)
        {
            float result=0 ;
            if ((D==0)||(X==0))
                {//invalid data
                result = -1;
                }
            else
            {//correct data
             float time = D / ( 2 * X);
             float bird_distance = 2 * X * time;
             result = bird_distance;
            }
            return result;
        }
    }
}
