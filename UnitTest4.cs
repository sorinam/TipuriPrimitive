using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestSquareImproperDimension()
        {
            float lung_p = 0;
            float lat_p = 7;
            float a = 4;
            int expected_result = 0;
            Calculate classCalculate = new Calculate();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);

        }
    }
}
