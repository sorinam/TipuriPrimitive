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
            ulong ExpectedChanse = 566684;
            Utils utils = new Utils();
            Assert.AreEqual(ExpectedChanse, utils.ChancetoWin(TotalNumbers, Numbers));
            //Assert.AreEqual(ExpectedChanse, utils.Combinations(TotalNumbers, Numbers));
        }
       
    }
}
