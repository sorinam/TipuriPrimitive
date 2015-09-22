using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Excel_InvalidColNb
    {
        [TestMethod]
        public void Excel_InvalidColumnNumber()
        {
            int column_number =0;
            string expected_result = "-1";
            Excel_CalculateColumnName calculateColumnName = new Excel_CalculateColumnName();
            string result = calculateColumnName.ColumnName(column_number);
            Assert.AreEqual(expected_result, result);
        }
    }
}
