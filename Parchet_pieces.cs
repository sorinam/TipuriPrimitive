using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipuriPrimitive
{
    class Parchet_pieces
    {
        public int CalculatenumberofPieces(float M, float N, float A, float B, float extra)
        {
            int result;
            if (M * N * A * B != 0)
            {if (M > 0 && N > 0 && A > 0 && B > 0)
                {
                    //valid dimensions
                    float calculate;
                    float area1;
                    //calculate the area of the room
                    area1 = M * N;
                    //calculate de area of a pieces of parquet
                    float area2 = A * B;
                    //calculate number of pieces
                    calculate = area1 / area2;
                    //put extra needed
                    calculate = calculate * (1 + extra);
                    result = (int)(Math.Ceiling(calculate));
                }
            else
                {//invalid dimensions; one zise is negative
                    result = -1;
                }
            }
            else
            {//invalid dimesions, one size equal to 0
                result = -1;
            }
            return result;

        }
    }
}
