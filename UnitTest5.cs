using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void Excel_TestOneLetterDiffZ()
        {
            int column_number = 25;
            string expected_result = "Z";
            Excel_CalculateColumnName calculateColumnName = new Excel_CalculateColumnName();
            string result = calculateColumnName.ColumnName(column_number);
            Assert.AreEqual(expected_result, result);
        }
    }
}
