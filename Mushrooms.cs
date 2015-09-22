using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Mushrooms
    {
        public int CalculateWhiteMushrroms(int N,int X)
        {
            int result = 0;
            if (X > N)
            {//no solution- incorrect data 
                result = -1;
            }
            else
            {
                if (N % (X + 1) == 0)
                {//have solution
                    result = N / (X + 1);
                }
            }
            return result;

        }
    }
}
