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

            Assert.IsTrue(baseNumber != 10);
            Assert.AreEqual(expectedDigitsXBase.Count, calculateDigitsXBase.Count);
            Assert.IsTrue(AreEqualLists(expectedDigitsXBase, calculateDigitsXBase));
        }

        [TestMethod]
        public void ConvertFromDecimalToHexa()
        {
            int baseNumber = 16;
            int inputNumber = 234;
            List<byte> expectedDigitsXBase = new List<byte>();
            expectedDigitsXBase.Add(Convert.ToByte('A'));
            expectedDigitsXBase.Add(Convert.ToByte('E'));

            List<byte> calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.IsTrue(baseNumber != 10);
            Assert.AreEqual(expectedDigitsXBase.Count, calculateDigitsXBase.Count);
            Assert.IsTrue(AreEqualLists(expectedDigitsXBase, calculateDigitsXBase));
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
            Assert.IsTrue(AreEqualLists(expectedDigitsXBase,calculateDigitsXBase));
        }

        private bool AreEqualLists(List<byte>List1, List<byte> List2)
        {
            if (List1.Count != List2.Count)
                {
                return false;
                }
            for (int i=0; i< List1.Count;i++)
            if (List1[i] != List2[i])
                {
                    return false;
                }
            return true;
        }

        private static List<byte> ConvertFromDecimalToAnotherBase(int decimalNumber, int baseNumber)
        {
            List<byte> digits = new List<byte>();
            int division;
            byte rest;
            byte char1 = 0; ;
            do
            {
                division = (decimalNumber / baseNumber);
                rest = (byte)(decimalNumber % baseNumber);
                decimalNumber = division;
                if (baseNumber >10)
                {
                    char1 = Convert.ToByte(ReplaceDigitwithLetter(rest));
                }
                else
                {
                    char1 = rest;
                }
                digits.Add(char1);
            }
            while (decimalNumber > 0);
            
            return digits;
        }
        
        private static char ReplaceDigitwithLetter(byte v)
        {
            char letter;
            return letter = (char)('A' + v - 10);
        }
    }
}

