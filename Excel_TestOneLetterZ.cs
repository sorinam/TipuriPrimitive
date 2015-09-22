using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Excel_TestOneLetterZ
    {
        [TestMethod]
        public void Excel_TestLetterZ()
        {
            int column_number = 26;
            string expected_result = "Z";
            Excel_CalculateColumnName calculateColumnName = new Excel_CalculateColumnName();
            string result = calculateColumnName.ColumnName(column_number);
            Assert.AreEqual(expected_result, result);
        }
    }
}
