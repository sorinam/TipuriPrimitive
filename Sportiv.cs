using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Sportiv
    {
        [TestMethod]
        public void Sportiv_CalculNrTotalRunde()
        {
            int nr_runde = 10;
            int expected_result = 100;
            //expected result is nr_runde*^2
            int result = CalculRunde(nr_runde);
            Assert.AreEqual(expected_result, result);
        }
        public int CalculRunde(int N)
        {
            int result = 0;
            for (int i = 1; i <= N; i++)
            {
                result = result + i;
            }
            for (int i = N - 1; i > 0; i--)
            {
                result = result + i;
            }
            return result;
        }
    }
}
