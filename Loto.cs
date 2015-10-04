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
            uint TotalNumbers = 49;
            uint Numbers = 6;
            decimal ExpectedChanse = 7.1511238E-08M;
            Utils utils = new Utils();
            Assert.AreEqual(ExpectedChanse, utils.ChancetoWin(TotalNumbers, Numbers));
            
        }
        [TestMethod]
        public void CategoryIILoto()
        {
            uint TotalNumbers = 49;
            uint Numbers = 5;
            decimal ExpectedChanse = 1.8878966943E-05M;
            Utils utils = new Utils();
            Assert.AreEqual(ExpectedChanse, utils.ChancetoWin(TotalNumbers, Numbers));
        }
    }
}
