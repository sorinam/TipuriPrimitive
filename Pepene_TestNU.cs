using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Pepene_TestNU
    {
        [TestMethod]
        public void PepeneNU()
        {
            int x = 9;
            string expected_result = "NU";
            Pepene pepene = new Pepene();
            string result = pepene.Verify_Kg(x);
            Assert.AreEqual(expected_result, result);
        }
    }
}
