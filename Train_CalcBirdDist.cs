using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Train_CalcBirdDist
    {
        [TestMethod]
        public void Train_CalculateBirdDistance()
        {
            float X = 3;
            float D = 10;
            CalcBirdDistance calcBirdDistance = new CalcBirdDistance();
            float result = 0;
            float expected_result = 10;
            result = calcBirdDistance.CalculateBirdDistance(D, X);
            Assert.AreEqual(expected_result, result);
        }
    }
}
