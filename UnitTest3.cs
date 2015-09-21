using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestDalaImproperDimensions()
        {
            float lung_p = 1;
            float lat_p = 7;
            float a = 0;
            int expected_result = -1;
            Calculate classCalculate = new Calculate();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);
        }
    }
}
