using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class ParchetInvalidDim
    {
        [TestMethod]
        public void Parchet_InvalidDimesnions()
        {//room dimension
            float M =0;
            float N = 3;
            //parquet dimensions
            float A = 0;
            float B = 0.15f;
            //extra
            float extra = 0.15f;
            Parchet_pieces parchet = new Parchet_pieces();
            int result = parchet.CalculatenumberofPieces(M, N, A, B, extra);
            int expected_result = -1;
            Assert.AreEqual(expected_result, result);
        }
    }
}
