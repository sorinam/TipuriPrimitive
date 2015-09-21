using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleCase()
        {
            // length%a = 0 and high%a=0
            int lung_p = 6;
            int lat_p = 8;
            int a = 2;
            int expected_result = 12;
            Calculate classCalculate = new Calculate();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);
        }
    }
}
