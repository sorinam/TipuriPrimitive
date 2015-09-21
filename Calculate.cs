using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Calculate
    {
        public int CalculDale(float m, float n, float a)
        {
            int result;
            if (a > 0)
            {
                if (m <= 0)
                {
                    //length of square is zero
                    result = 0;
                }
                else
                {
                    if (n <= 0)
                    {
                        //high of square is zero
                        result = 0;
                    }
                    else
                    {
                        var lung = Math.Ceiling(m / a);
                        var lat = Math.Ceiling(n / a);
                        result = (int)(lung * lat);
                    }
                }

            }
            else
            {
                //Dimesion of dala =0
                result = -1;
            }
            return result;
        }
    }
}
