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
            byte[] expectedDigitsXBase = { 2, 2, 2, 3 };

            var calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.IsTrue(baseNumber != 10);
            Assert.AreEqual(expectedDigitsXBase.Length, calculateDigitsXBase.Length);
            CollectionAssert.AreEqual(expectedDigitsXBase, calculateDigitsXBase);
        }

        [TestMethod]
        public void ConvertFromDecimalToHexa()
        {
            int baseNumber = 16;
            int inputNumber = 234;
            byte[] expectedDigitsXBase = { 10, 14 };

            var calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.IsTrue(baseNumber != 10);
            Assert.AreEqual(expectedDigitsXBase.Length, calculateDigitsXBase.Length);
            CollectionAssert.AreEqual(expectedDigitsXBase, calculateDigitsXBase);
        }

        [TestMethod]
        public void ConvertFromDecimalToBinary()
        {
            int baseNumber = 2;
            int inputNumber = 40;
            byte[] expectedDigitsXBase = { 0, 0, 0, 1, 0, 1 };

            var calculateDigitsXBase = ConvertFromDecimalToAnotherBase(inputNumber, baseNumber);

            Assert.AreEqual(expectedDigitsXBase.Length, calculateDigitsXBase.Length);
            CollectionAssert.AreEqual(expectedDigitsXBase, calculateDigitsXBase);
        }

        [TestMethod]
        public void ConvertFromXBaseToDecimal()
        {
            int baseNumber = 2;
            byte[] inputNumber = { 0, 1, 0, 1, 0, 0, 1, 1, 1 };
            int expectedNumber = 458;

            var calculateNumber = ConvertFromXBaseToDecimal(inputNumber, baseNumber);

            Assert.AreEqual(expectedNumber, calculateNumber);
        }

        [TestMethod]
        public void ConvertFromHexaToDecimal()
        {
            int baseNumber = 16;
            byte[] inputNumber = { 14, 5, 2, 12, 7, 4, 13 };
            int expectedNumber = 222806622;

            var calculateNumber = ConvertFromXBaseToDecimal(inputNumber, baseNumber);

            Assert.AreEqual(expectedNumber, calculateNumber);
        }

        [TestMethod]
        public void ConvertFromXBaseToYBase()
        {
            int Xbase = 16;
            int Ybase = 2;
            byte[] inputNumber = { 4, 1 };
            byte[] expectedNumber = { 0, 0, 1, 0, 1 };

            var calculateNumber = ConvertFromXBaseToYBase(inputNumber, Xbase, Ybase);

            CollectionAssert.AreEqual(expectedNumber, calculateNumber);
        }

        [TestMethod]
        public void ANDForListsWithDifferentLength()
        {
            byte[] firstArray = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 1, 0, 1 };
            byte[] resultArray = { 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            byte[] calculateList = List1AndList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void ANDForListsWithTheSameLength()
        {
            byte[] firstArray = { 1, 1, 1, 1 };
            byte[] secondArray = { 1, 1, 1, 0 };
            byte[] resultArray = { 1, 1, 1, 0 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            var calculateList = List1AndList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void ORForListsWithDifferentLength()
        {
            byte[] firstArray = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 1, 0, 1 };
            byte[] resultArray = { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            byte[] calculateList = List1OrList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void ORForListsWithTheSameLength()
        {

            byte[] firstArray = { 1, 1, 0, 0 };
            byte[] secondArray = { 0, 1, 1, 0 };
            byte[] resultArray = { 1, 1, 1, 0 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            var calculateList = List1OrList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void XORForListsWithDifferentLength()
        {
            byte[] firstArray = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 1, 0, 1 };
            byte[] resultArray = { 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            var calculateList = List1XorList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void XORForListsWithTheSameLength()
        {
            byte[] firstArray = { 1, 1, 0, 0 };
            byte[] secondArray = { 0, 1, 1, 0 };
            byte[] resultArray = { 1, 0, 1, 0 };

            Assert.IsTrue(IsListValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsListValid(secondArray), "Invalid SecondArray");

            var calculateList = List1XorList2(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void NotForList()
        {
            byte[] inputArray = { 1, 1, 0, 0 };

            byte[] resultArray = { 0, 0, 1, 1 };

            Assert.IsTrue(IsListValid(inputArray), "Invalid inputArray");

            var calculateArray = NotList(inputArray);

            CollectionAssert.AreEqual(resultArray, calculateArray);
        }

        private static bool IsListValid(byte[] listi)
        {
            foreach (byte b in listi)
            {
                if ((b != 0) && (b != 1))
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] List1AndList2(byte[] List1, byte[] List2)
        {
            byte[] resultArray = new byte[16];
            for (int i = 0; i < Math.Min(List1.Length, List2.Length); i++)
            {
                resultArray[i] = AndForBytes(List1[i], List2[i]);
            }
            if (List1.Length > List2.Length)
            {
                //resultArray.AddRange(List1.GetRange(List2.Count, List1.Count - List2.Count));

            }
            else
            {
                //resultArray.AddRange(List2.GetRange(List1.Count, List2.Count - List1.Count));
            }
            Array.Resize(ref resultArray, Math.Max(List1.Length, List2.Length));
            return resultArray;
        }

        private static byte[] List1OrList2(byte[] List1, byte[] List2)
        {
            byte[] resultArray = new byte[16];
            for (int i = 0; i < Math.Min(List1.Length, List2.Length); i++)
            {
                resultArray[i] = OrForBytes(List1[i], List2[i]);
            }
            return ResizeResultArray(List1,List2,ref resultArray);
        }

        private static byte[] ResizeResultArray(byte[] firstList, byte[] secondList,ref byte[] destinationList)
        {
            if (firstList.Length == secondList.Length)
            {
                Array.Resize(ref destinationList, firstList.Length);
                return destinationList;
            }
            else
            {
                byte[] difArray = new byte[16];
                if (firstList.Length > secondList.Length)
                {
                    difArray = GetRangeOfArray(firstList, secondList.Length, firstList.Length - secondList.Length);
                    Array.Resize(ref destinationList, Math.Min(firstList.Length, secondList.Length));
                }
                else
                {
                difArray = GetRangeOfArray(secondList, firstList.Length, secondList.Length - firstList.Length);
                Array.Resize(ref destinationList, Math.Min(firstList.Length, secondList.Length));
                }
             return AddRangeOfArray(destinationList, difArray);
            }
        }

        private static byte[] List1XorList2(byte[] List1, byte[] List2)
        {
            byte[] resultArray = new byte[16];
            for (int i = 0; i < Math.Min(List1.Length, List2.Length); i++)
            {
                resultArray[i] = XorForBytes(List1[i], List2[i]);
            }
            if (List1.Length > List2.Length)
            {
                //resultArray.AddRange(List1.GetRange(List2.Count, List1.Count - List2.Count));

            }
            else
            {
                // resultArray.AddRange(List2.GetRange(List1.Count, List2.Count - List1.Count));
            }
            Array.Resize(ref resultArray, Math.Max(List1.Length, List2.Length));
            return resultArray;
        }

        private static byte[] NotList(byte[] List1)
        {
            byte[] resultList = new byte[16];
            for (int i = 0; i < List1.Length; i++)
            {
                resultList[i] = NotForByte(List1[i]);
            }

            return resultList;
        }

        private static byte AndForBytes(byte c1, byte c2)
        {
            return (c1 == c2) ? c1 : (byte)0;
        }

        private static byte OrForBytes(byte c1, byte c2)
        {
            return ((c1 == 1) || (c2 == 1)) ? (byte)1 : (byte)0;
        }

        private static byte XorForBytes(byte c1, byte c2)
        {
            return ((c1 == c2)) ? (byte)0 : (byte)1;
        }

        private static byte NotForByte(byte c1)
        {
            return ((c1 == 1)) ? (byte)0 : (byte)1;
        }

        private static byte[] ConvertFromXBaseToYBase(byte[] inputNumber, int xbase, int ybase)
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

        private static int CalculateNoFromList(byte[] inputNumber)
        {
            int result = 0;
            for (int i = 0; i < inputNumber.Length; i++)
            {
                result += inputNumber[i] * (int)Math.Pow(10, i);
            }
            return result;
        }

        private static int ConvertFromXBaseToDecimal(byte[] inputNumber, int baseNumber)
        {
            int result = 0;
            for (int i = 0; i < inputNumber.Length; i++)
            {
                result += inputNumber[i] * (int)Math.Pow(baseNumber, i);
            }
            return result;
        }

        private static byte[] ConvertFromDecimalToAnotherBase(int decimalNumber, int baseNumber)
        {
            byte[] digits = new byte[16];
            int division;
            byte rest;
            int i = 0;
            do
            {
                division = (decimalNumber / baseNumber);
                rest = (byte)(decimalNumber % baseNumber);
                decimalNumber = division;
                //AddToArray(ref digits,charR);
                digits[i] = rest;
                i++;
            }
            while (decimalNumber > 0);
            Array.Resize(ref digits, i);
            return digits;
        }

        private static byte[] GetRangeOfArray(byte[] inputArray, int index, int length)
        {
            byte[] resultArray = new byte[16];
            if (index < inputArray.Length)
            {
                int j = 0;
                for (int i = index; i < Math.Min(index + length, inputArray.Length); i++)
                {
                    resultArray[j] = inputArray[i];
                    j++;
                }
                Array.Resize(ref resultArray, j);
                return resultArray;
            }
            else
                return null;

        }

        private static byte[] AddRangeOfArray(byte[] destinationArray, byte[] sourceArray)
        {
            byte[] resultArray = new byte[destinationArray.Length + sourceArray.Length];
            destinationArray.CopyTo(resultArray, 0);

            if (sourceArray.Length > 0)
            {
                int j = 0;
                for (int i = destinationArray.Length; i < destinationArray.Length + sourceArray.Length; i++)
                {
                    resultArray[i] = sourceArray[j];
                    j++;
                }
                return resultArray;
            }
            else
                return null;

        }
    }
}

