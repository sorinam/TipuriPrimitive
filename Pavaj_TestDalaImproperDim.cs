using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Pavaj_TestDalaImproperDim
    {
        [TestMethod]
        public void Pavaj_TestDalaImproperDimensions()
        {
            float lung_p = 1;
            float lat_p = 7;
            float a = 0;
            int expected_result = -1;
            CalculateDale classCalculate = new CalculateDale();
            int result = classCalculate.CalculDale(lung_p, lat_p, a);
            Assert.AreEqual(expected_result, result);
        }
    }
}
