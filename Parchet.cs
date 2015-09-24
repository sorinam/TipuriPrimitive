using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Parchet
    {
        [TestMethod]
        public void Parchet_NumberofPieces()
        {//room dimension
            float M = 10;
            float N = 3;
            //parquet dimensions
            float A = 0.8f;
            float B =0.15f;
            //extra
            float extra = 0.15f;
            Parchet_pieces parchet = new Parchet_pieces();
            int result = parchet.CalculatenumberofPieces(M,N,A,B,extra);
            int expected_result = 288;
            Assert.AreEqual(expected_result, result);

        }
    }
}
