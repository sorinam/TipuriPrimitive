using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Mushrroms_HaveSolution
    {
        [TestMethod]
        public void Mushrooms_Solution()
        {
            int N = 10;
            int X = 4;
            Mushrooms mushrooms = new Mushrooms();
            int white_mushrooms = 0;
            int red_mushrooms = 0;
            int expected_whitemushrooms = 2;
            int expected_redmushrooms = 8;
            white_mushrooms = mushrooms.CalculateWhiteMushrroms(N, X);
            red_mushrooms = X * white_mushrooms;
            Assert.AreEqual(expected_whitemushrooms, white_mushrooms);
            Assert.AreEqual(expected_redmushrooms, red_mushrooms);
        }
    }
}
