using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Loto
    {
        [TestMethod]
        public void SixNumbers()
        {
            ulong TotalNumbers = 49;
            ulong Numbers = 6;
            ulong ExpectedChanse = 566684;
            Utils utils= new Utils();
            Assert.AreEqual(ExpectedChanse,utils.ChancetoWin(TotalNumbers, Numbers));
          
        }
    }
}
