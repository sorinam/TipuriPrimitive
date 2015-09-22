using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Excel_Test1to25
    {
        [TestMethod]
        public void Excel_TestOneLetterDiffZ()
        {
            int column_number = 1;
            string expected_result = "A";
            Excel_CalculateColumnName calculateColumnName = new Excel_CalculateColumnName();
            string result = calculateColumnName.ColumnName(column_number);
            Assert.AreEqual(expected_result, result);
        }
    }
}
