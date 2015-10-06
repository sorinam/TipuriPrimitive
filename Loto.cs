using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Loto
    {
        [TestMethod]
        public void CategoryILoto()
        {
            uint totalNumbers = 49;
            uint numbers = 6;
            decimal expectedChanse = 7.1511238E-08M;
            Utils utils = new Utils();
            Assert.AreEqual(expectedChanse, utils.ChancetoWin(totalNumbers, numbers));
            
        }
        [TestMethod]
        public void CategoryIiLoto()
        {
            uint totalNumbers = 49;
            uint numbers = 5;
            decimal expectedChanse = 1.8878966943E-05M;
            Utils utils = new Utils();
            Assert.AreEqual(expectedChanse, utils.ChancetoWin(totalNumbers, numbers));
        }
        [TestMethod]
        public void CategoryIiiLoto()
        {
            uint totalNumbers = 49;
            uint numbers = 4;
            decimal expectedChanse = 1.061941890540E-03M;
            Utils utils = new Utils();
            Assert.AreEqual(expectedChanse, utils.ChancetoWin(totalNumbers, numbers));
        }
    }
}
