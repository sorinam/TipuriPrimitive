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
        public void PerformANDForArraysWithDifferentLength()
        {
            byte[] firstArray = { 0, 0, 1, 1, 1, 0, 1, 1 };
            byte[] secondArray = { 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1 };
            byte[] resultArray = { 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            byte[] calculateList = PerformANDLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformANDForArraysWithTheSameLength()
        {
            byte[] firstArray = { 1, 1, 1, 1, 1, 0, 0, 1, };
            byte[] secondArray = { 1, 1, 1, 0, 0, 0, 1, 1 };
            byte[] resultArray = { 1, 1, 1, 0, 0, 0, 0, 1 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            var calculateList = PerformANDLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformORForArrayssWithDifferentLength()
        {

            byte[] firstArray = { 0, 0, 1, 1, 1, 0, 1, 1 };
            byte[] secondArray = { 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1 };
            byte[] resultArray = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            byte[] calculateList = PerformORLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformORForArraysWithTheSameLength()
        {

            byte[] firstArray = { 1, 1, 0, 0, 1, 1, 0, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 0, 0, 0, 1 };
            byte[] resultArray = { 1, 1, 1, 0, 1, 1, 0, 1 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            var calculateList = PerformORLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformXORForArraysWithDifferentLength()
        {
            byte[] firstArray = { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 1, 0, 1, 0 };
            byte[] resultArray = { 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            var calculateList = PerformXORLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformXORForArraysWithTheSameLength()
        {
            byte[] firstArray = { 1, 1, 0, 0, 1, 1, 1, 1 };
            byte[] secondArray = { 0, 1, 1, 0, 0, 0, 0, 1 };
            byte[] resultArray = { 1, 0, 1, 0, 1, 1, 1, 0 };

            Assert.IsTrue(IsArrayValid(firstArray), "Invalid FirstArray");
            Assert.IsTrue(IsArrayValid(secondArray), "Invalid SecondArray");

            var calculateList = PerformXORLogicalToArrays(firstArray, secondArray);

            CollectionAssert.AreEqual(resultArray, calculateList);
        }

        [TestMethod]
        public void PerformNOTForArray()
        {
            byte[] inputArray = { 1, 1, 0, 0, 1, 1, 1, 1 };

            byte[] resultArray = { 0, 0, 1, 1, 0, 0, 0, 0 };

            Assert.IsTrue(IsArrayValid(inputArray), "Invalid inputArray");

            var calculateArray = PerformNOTLogicalToArray(inputArray);

            CollectionAssert.AreEqual(resultArray, calculateArray);
        }

        [TestMethod]
        public void LShiftForArray()
        {
            byte[] inputArray = { 1, 1, 0, 0, 0, 0, 1, 1 };

            byte[] resultArray = { 0, 1, 1, 0, 0, 0, 0, 1 };

            Assert.IsTrue(IsArrayValid(inputArray), "Invalid inputArray");

            ApplyLShiftToArray(ref inputArray);

            CollectionAssert.AreEqual(resultArray, inputArray);
        }

        [TestMethod]
        public void RShiftForArray()
        {
            byte[] inputArray = { 0, 1, 1, 0, 1, 1, 1, 0 };
            byte[] resultArray = { 1, 1, 0, 1, 1, 1, 0, 0 };

            Assert.IsTrue(IsArrayValid(inputArray), "Invalid inputArray");

            ApplyRShiftToArray(ref inputArray);
            CollectionAssert.AreEqual(resultArray, inputArray);
        }

        private static void ApplyLShiftToArray(ref byte[] inputArray)
        {
            for (int i = inputArray.Length - 1; i > 0; i--)
            {
                inputArray[i] = inputArray[i - 1];
            }
            inputArray[0] = 0;

        }

        private static void ApplyRShiftToArray(ref byte[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                inputArray[i] = inputArray[i + 1];
            }
            inputArray[inputArray.Length - 1] = 0;

        }

        private static bool IsArrayValid(byte[] inputArray)
        {
            foreach (byte b in inputArray)
            {
                if ((b != 0) && (b != 1))
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] PerformANDLogicalToArrays(byte[] firstArray, byte[] secondArray)
        {
            var index = GetIndexOfResultArray(Math.Max(firstArray.Length, secondArray.Length));
            byte[] resultArray = new byte[index];
            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                resultArray[i] = AndForByte(firstArray[i], secondArray[i]);
            }
            return FillResultArray(firstArray, secondArray, ref resultArray);
        }

        private static int GetIndexOfResultArray(int refIndex)
        {
            if (refIndex <= 8)
            {
                return 8;
            }
            else
            {
                if (refIndex <= 16)
                {
                    return 16;
                }
                else
                {
                    if (refIndex <= 32)
                    {
                        return 32;
                    }
                    else
                    {
                        return 64;
                    }
                }
            }
        }

        private static byte[] PerformORLogicalToArrays(byte[] firstArray, byte[] secondArray)
        {
            byte[] resultArray = new byte[GetIndexOfResultArray(Math.Max(firstArray.Length, secondArray.Length))];
            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                resultArray[i] = OrForByte(firstArray[i], secondArray[i]);
            }
            return FillResultArray(firstArray, secondArray, ref resultArray);
        }

        private static byte[] PerformXORLogicalToArrays(byte[] firstArray, byte[] secondArray)
        {
            byte[] resultArray = new byte[GetIndexOfResultArray(Math.Max(firstArray.Length, secondArray.Length))];
            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                resultArray[i] = XorForByte(firstArray[i], secondArray[i]);
            }
            return FillResultArray(firstArray, secondArray, ref resultArray);
        }

        private static byte[] PerformNOTLogicalToArray(byte[] inputArray)
        {
            byte[] resultArray = new byte[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                resultArray[i] = NotForByte(inputArray[i]);
            }

            return resultArray;
        }

        private static byte AndForByte(byte c1, byte c2)
        {
            return (c1 == c2) ? c1 : (byte)0;
        }

        private static byte OrForByte(byte c1, byte c2)
        {
            return ((c1 == 1) || (c2 == 1)) ? (byte)1 : (byte)0;
        }

        private static byte XorForByte(byte c1, byte c2)
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
                int decimalNo = CalculateDecimalNumberFromArray(inputNumber);
                return ConvertFromDecimalToAnotherBase(decimalNo, ybase);
            }
            else
            {
                int decimalNo = ConvertFromXBaseToDecimal(inputNumber, xbase);
                return ConvertFromDecimalToAnotherBase(decimalNo, 10);
            }
        }

        private static int CalculateDecimalNumberFromArray(byte[] inputNumber)
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
                digits[i] = rest;
                i++;
            }
            while (decimalNumber > 0);
            Array.Resize(ref digits, i);
            return digits;
        }

        private static byte[] FillResultArray(byte[] firstArray, byte[] secondArray, ref byte[] destinationList)
        {
            if (firstArray.Length == secondArray.Length)
            {
                Array.Resize(ref destinationList, firstArray.Length);
                return destinationList;
            }
            else
            {
                byte[] difArray = new byte[GetIndexOfResultArray(Math.Abs(firstArray.Length - secondArray.Length))];
                if (firstArray.Length > secondArray.Length)
                {
                    difArray = GetRangeOfArray(firstArray, secondArray.Length, firstArray.Length - secondArray.Length);
                }
                else
                {
                    difArray = GetRangeOfArray(secondArray, firstArray.Length, secondArray.Length - firstArray.Length);
                }
                Array.Resize(ref destinationList, Math.Min(firstArray.Length, secondArray.Length));
                return AddRangeOfArray(destinationList, difArray);
            }
        }

        private static byte[] GetRangeOfArray(byte[] inputArray, int index, int length)
        {
            byte[] resultArray = new byte[GetIndexOfResultArray(length)];
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

