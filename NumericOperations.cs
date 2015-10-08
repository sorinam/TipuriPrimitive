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
        [TestMethod]
        public void ConvertFromDecimalToBinary()
        {
            int baseNumber = 2;
            int inputNumber = 40;
            List<byte> expectedDigitsXBase = new List<byte>();
            
            expectedDigitsXBase.Add(0);
            expectedDigitsXBase.Add(0);
            expectedDigitsXBase.Add(0);
            expectedDigitsXBase.Add(1);
            expectedDigitsXBase.Add(0);
            expectedDigitsXBase.Add(1);

            List<byte> calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.AreEqual(expectedDigitsXBase.Count, calculateDigitsXBase.Count);
            CollectionAssert.Equals(expectedDigitsXBase, calculateDigitsXBase);

        }
        private static List<byte> ConvertFromDecimalToAnotherBase(int decimalNumber, int baseNumber)
        {
            List<byte> digits = new List<byte>();
            int division;
            byte rest;
            do
            {
                division = (decimalNumber / baseNumber);
                rest = (byte)(decimalNumber % baseNumber);
                decimalNumber = division;
                digits.Add(rest);
            }
            while (decimalNumber > 0);
            return digits;
        }
    }
}

