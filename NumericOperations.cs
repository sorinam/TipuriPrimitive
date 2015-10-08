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

        [TestMethod]
        public void ANDForListsWithDifferentLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);

            List<byte> List2 = new List<byte>();
            List2.Add(0);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);

            List<byte> resultList = new List<byte>();
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(0);
            resultList.Add(0);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1AndList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void ANDForListsWithTheSameLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);

            List<byte> List2 = new List<byte>();
            List2.Add(1);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);

            List<byte> resultList = new List<byte>();
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(0);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1AndList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void ORForListsWithDifferentLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);

            List<byte> List2 = new List<byte>();
            List2.Add(0);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);

            List<byte> resultList = new List<byte>();
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1OrList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void ORForListsWithTheSameLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(0);

            List<byte> List2 = new List<byte>();
            List2.Add(0);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);

            List<byte> resultList = new List<byte>();
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(0);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1OrList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void XORForListsWithDifferentLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);
            List1.Add(0);
            List1.Add(1);

            List<byte> List2 = new List<byte>();
            List2.Add(0);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);
            List2.Add(0);
            List2.Add(1);

            List<byte> resultList = new List<byte>();
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1XorList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void XORForListsWithTheSameLength()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(0);

            List<byte> List2 = new List<byte>();
            List2.Add(0);
            List2.Add(1);
            List2.Add(1);
            List2.Add(0);

            List<byte> resultList = new List<byte>();
            resultList.Add(1);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(0);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");
            Assert.IsTrue(IsListValid(List2), "Invalid List2");

            List<byte> calculateList = List1XorList2(List1, List2);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        [TestMethod]
        public void NotForList()
        {
            List<byte> List1 = new List<byte>();
            List1.Add(1);
            List1.Add(1);
            List1.Add(0);
            List1.Add(0);

            List<byte> resultList = new List<byte>();
            resultList.Add(0);
            resultList.Add(0);
            resultList.Add(1);
            resultList.Add(1);

            Assert.IsTrue(IsListValid(List1), "Invalid List1");

            List<byte> calculateList = NotList(List1);

            Assert.IsTrue(AreEqualLists(resultList, calculateList));
        }

        private static bool IsListValid(List<byte> listi)
        {
            string good = "01";
            foreach (byte b in listi)
            {
                if (!(good.Contains(Convert.ToString(b))))
                {
                    return false;
                }
            }
            return true;
        }

        private static List<byte> List1AndList2(List<byte> List1, List<byte> List2)
        {
            List<byte> List3 = new List<byte>();
            for (int i = 0; i < Math.Min(List1.Count, List2.Count); i++)
            {
                List3.Add(AndForBytes(List1[i], List2[i]));
            }
            if (List1.Count > List2.Count)
            {
                List3.AddRange(List1.GetRange(List2.Count, List1.Count - List2.Count));

            }
            else
            {
                List3.AddRange(List2.GetRange(List1.Count, List2.Count - List1.Count));
            }
            return List3;
        }

        private static List<byte> List1OrList2(List<byte> List1, List<byte> List2)
        {
            List<byte> List3 = new List<byte>();
            for (int i = 0; i < Math.Min(List1.Count, List2.Count); i++)
            {
                List3.Add(OrForBytes(List1[i], List2[i]));
            }
            if (List1.Count > List2.Count)
            {
                List3.AddRange(List1.GetRange(List2.Count, List1.Count - List2.Count));

            }
            else
            {
                List3.AddRange(List2.GetRange(List1.Count, List2.Count - List1.Count));
            }
            return List3;
        }

        private static List<byte> List1XorList2(List<byte> List1, List<byte> List2)
        {
            List<byte> List3 = new List<byte>();
            for (int i = 0; i < Math.Min(List1.Count, List2.Count); i++)
            {
                List3.Add(XorForBytes(List1[i], List2[i]));
            }
            if (List1.Count > List2.Count)
            {
                List3.AddRange(List1.GetRange(List2.Count, List1.Count - List2.Count));

            }
            else
            {
                List3.AddRange(List2.GetRange(List1.Count, List2.Count - List1.Count));
            }
            return List3;
        }

        private static List<byte> NotList(List<byte> List1)
        {
            List<byte> List2 = new List<byte>();
            for (int i = 0; i < List1.Count; i++)
            {
                List2.Add(NotForByte(List1[i]));
            }

            return List2;
        }

        private static byte AndForBytes(byte c1, byte c2)
        {
            return (c1 == c2) ? c1 : Convert.ToByte(0);
        }

        private static byte OrForBytes(byte c1, byte c2)
        {
            return ((c1 == 1) || (c2 == 1)) ? Convert.ToByte(1) : Convert.ToByte(0);
        }

        private static byte XorForBytes(byte c1, byte c2)
        {
            return ((c1 == c2)) ? Convert.ToByte(0) : Convert.ToByte(1);
        }

        private static byte NotForByte(byte c1)
        {
            return ((c1 == 1)) ? Convert.ToByte(0) : Convert.ToByte(1);
        }

        private static List<byte> ConvertFromXBaseToYBase(List<byte> inputNumber, int xbase, int ybase)
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

        private static int CalculateNoFromList(List<byte> inputNumber)
        {
            int result = 0;
            for (int i = 0; i <= inputNumber.Count; i++)
            {
                result += inputNumber[i] * (int)Math.Pow(10, i);
            }
            return result;
        }

        private static int ConvertFromXBaseToDecimal(List<byte> inputNumber, int baseNumber)
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

        private static bool IfCharIsValid(byte v, out int value)
        {
            bool result = false;
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

        private static int GetNumberFromLetter(char c)
        {
            return 10 + c - 'A';

        }

        private static bool AreEqualLists(List<byte> List1, List<byte> List2)
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

