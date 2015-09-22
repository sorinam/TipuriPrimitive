using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class OneDayOneGoat
    {
        [TestMethod]
        public void O1DayOneGoat()
        {
            int Xdays = 5;
            int Ygoats = 3;
            int Zkg = 10;
            int Wdays = 1;
            int Qgoats = 1;
            float result = 0;
            Goats goats = new Goats();
            float expected_result = 0.6666667F;
            result = goats.CalculateCant(Xdays, Ygoats, Zkg, Wdays, Qgoats);
            Assert.AreEqual(expected_result, result);

        }
    }
}
