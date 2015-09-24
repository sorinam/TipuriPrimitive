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
            float calculate;
            float area1;
            //calculate the area of the room
            area1 = M * N;
            //calculate de area of a pieces of parquet
            float area2 = A * B;
            //calculate number of pieces
            calculate = area1 / area2;
            //put extra needed
            calculate = calculate * (1+extra);
            result = (int)(Math.Ceiling(calculate));
            return result;

        }
    }
}
