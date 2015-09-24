using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Columns_CalculateArea
    {
        public float Calculate_AreaofTriangle(float xa, float ya, float xb, float yb, float xc, float yc)
        { float result = 0;
            float area = Math.Abs(xa * yb + xb * yc + ya * xc - xc * yb - xa * yc - xb * ya);
            if (area == 0)
            {//collinear points-there is no solution;
                result = -1;
            }
            else
            {
                result = area / 2;
            }
            return result;
        }
    }
}
