using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipuriPrimitive
{
    [TestClass]
    public class NumericOperations
    {
        [TestMethod]
        public void ConvertFromDecimalToXBase()
        {
            int baseNumber = 4;
            int inputNumber = 234;
            List<byte> expectedDigitsXBase = new List<byte>();
            expectedDigitsXBase.Add(2);
            expectedDigitsXBase.Add(2);
            expectedDigitsXBase.Add(2);
            expectedDigitsXBase.Add(3);

            List<byte> calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.AreEqual(expectedDigitsXBase.Count, calculateDigitsXBase.Count);
            CollectionAssert.Equals(expectedDigitsXBase, calculateDigitsXBase);

        }
        private static List<byte> ConvertFromDecimalToAnotherBase(int decimalNumber, int baseNumber)
        {
            List<byte> digits = new List<byte>();
            int cat;
            byte rest;
            int i = 0;
            do
            {
                cat = (decimalNumber / baseNumber);
                rest = (byte)(decimalNumber % baseNumber);
                decimalNumber = cat;
                digits.Add(rest);
                i++;
            }
            while (decimalNumber > 0);
            return digits;
        }
    }
}

