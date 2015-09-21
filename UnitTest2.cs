using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestRoundNeeded()
        {
            //length%a !=0 or high%a !=0
            float lung_p = 7;
            float lat_p = 8;
            float a = 2;
            int expected_result = 16;
            Calculate classCalculate = new Calculate();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);
        }
    }
}
