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
            int baseNumber =4;
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
            Assert.IsTrue(AreEqualLists(expectedDigitsXBase, calculateDigitsXBase));
        }

        [TestMethod]
        public void ConvertFromXBaseToDecimal()
        {
            int baseNumber = 2;

            List<byte> inputNumber = new List<byte>();
            inputNumber.Add(0);
            inputNumber.Add(1);

            int expectedNumber = 2;

            int calculateNumber = ConvertFromXBaseToDecimal(inputNumber, baseNumber);

            Assert.AreEqual(expectedNumber, calculateNumber);
        }

        [TestMethod]
        public void ConvertFromHexaToDecimal()
        {
            int baseNumber = 16;

            List<byte> inputNumber = new List<byte>();
            inputNumber.Add(Convert.ToByte('E'));
            inputNumber.Add(5);
            inputNumber.Add(2);
            inputNumber.Add(Convert.ToByte('C'));
            inputNumber.Add(7);
            inputNumber.Add(4);
            inputNumber.Add(Convert.ToByte('D'));

            int expectedNumber = 222806622;
            int calculateNumber = ConvertFromXBaseToDecimal(inputNumber, baseNumber);

            Assert.AreEqual(expectedNumber, calculateNumber);
        }

        [TestMethod]
        public void ConvertFromXBaseToYBase()
        {
            int Xbase = 16;
            int Ybase = 2;

            List<byte> inputNumber = new List<byte>();
            inputNumber.Add(4);
            inputNumber.Add(1);

            List<byte> expectedNumber = new List<byte>();
            expectedNumber.Add(0);
            expectedNumber.Add(0);
            expectedNumber.Add(1);
            expectedNumber.Add(0);
            expectedNumber.Add(1);

            List<byte> calculateNumber = new List<byte>();

            calculateNumber = ConvertFromXBaseToYBase(inputNumber, Xbase, Ybase);

            Assert.IsTrue(AreEqualLists(expectedNumber, calculateNumber));
        }

        private List<byte> ConvertFromXBaseToYBase(List<byte> inputNumber, int xbase, int ybase)
        {
            if ((xbase != 10) && (ybase != 10))
            {
                int decimalNo = ConvertFromXBaseToDecimal(inputNumber, xbase);
                return ConvertFromDecimalToAnotherBase(decimalNo, ybase);
            }
            else
                if (xbase == 10)
            {
                int decimalNo = CalculateNoFromList(inputNumber);
                return ConvertFromDecimalToAnotherBase(decimalNo, ybase);
            }
            else
            {
                int decimalNo = ConvertFromXBaseToDecimal(inputNumber, xbase);
                return ConvertFromDecimalToAnotherBase(decimalNo, 10);
            }
        }
             
        private int CalculateNoFromList(List<byte> inputNumber)
        {
            int result = 0;
            for (int i = 0; i <= inputNumber.Count; i++)
            {
                result += inputNumber[i] * (int)Math.Pow(10, i);
            }
            return result;
        }

        private int ConvertFromXBaseToDecimal(List<byte> inputNumber, int baseNumber)
        {
            int result = 0;
            int value = 0;
            for (int i = 0; i < inputNumber.Count; i++)
            {
                if (IfCharIsValid(inputNumber[i], out value))
                {
                    result += value * (int)Math.Pow(baseNumber, i);
                }
                else
                {
                    return -1;
                }
            }
            return result;
        }

        private bool IfCharIsValid(byte v, out int value)
        {
            bool result = true;
            if (char.IsUpper(Convert.ToChar(v)))
            {
                value = GetNumberFromLetter(Convert.ToChar(v));
                result = true;
            }
            else
            {
                result = true;
                value = (int)v;
            }
            return result;
        }

        private int GetNumberFromLetter(char c)
        {
            return 10 + c - 'A';

        }

        private bool AreEqualLists(List<byte> List1, List<byte> List2)
        {
            if (List1.Count != List2.Count)
            {
                return false;
            }
            for (int i = 0; i < List1.Count; i++)
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
                if (baseNumber > 10)
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

