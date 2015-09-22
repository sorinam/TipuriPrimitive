using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Pepene_TestDA
    {
        [TestMethod]
        public void Pepene_DA()
        {
            Pepene pepene = new Pepene();
            int x = 8;
            string expected_result = "DA";
            string result = pepene.Verify_Kg(x);
            Assert.AreEqual(expected_result, result);

        }
    }
}
