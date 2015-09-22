using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Mushrooms_InvalidX
    {
        [TestMethod]
        public void Mushrooms_InvalidData()
        {
            int N = 10;
            int X = 11;
            Mushrooms mushrooms = new Mushrooms();
            int white_mushrooms = 0;
            int expected_whitemushrooms = -1;
            white_mushrooms = mushrooms.CalculateWhiteMushrroms(N, X);
            Assert.AreEqual(expected_whitemushrooms, white_mushrooms);
        }
    }
}
