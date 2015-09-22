using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Train_InvalidData
    {
        [TestMethod]
        public void Train_ImproperInputData()
        {
            int X = 0;
            int D = 10;
            CalcBirdDistance calcBirdDistance = new CalcBirdDistance();
            float result = 0;
            float expected_result = -1;
            result = calcBirdDistance.CalculateBirdDistance(D,X);
            Assert.AreEqual(expected_result,result);
        }
    }
}
