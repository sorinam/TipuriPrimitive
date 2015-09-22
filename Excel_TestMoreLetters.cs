using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Excel_TestMoreLetters
    {
        [TestMethod]
        public void Excel_TestsMoreLetters()
        {
            int column_number = 18280;
            string expected_result = "AAAB";
            Excel_CalculateColumnName calculateColumnName = new Excel_CalculateColumnName();
            string result = calculateColumnName.ColumnName(column_number);
            Assert.AreEqual(expected_result, result);
        }
    }
}
