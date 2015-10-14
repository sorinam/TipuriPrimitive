using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Recursivitate
    {
        [TestMethod]
        public void ReverseString()
        {
            String inputString = "mama are mere";
            String outputString = "erem era amam";
            var calculateString = ReverseString(inputString);
            Assert.AreEqual(calculateString, outputString);
        }

        [TestMethod]
        public void ReverseEmptyString()
        {
            String inputString = "";
            String outputString = "";
            var calculateString = ReverseString(inputString);
            Assert.AreEqual(calculateString, outputString);
        }

        [TestMethod]
        public void ReplaceOneCharWithAnotherIntoAString()
        {
            String inputString = "#An#a a#re#m$%sere %mul#te";
            char charToReplace = '#';
            char newChar = '%';
            String expectedString = "%An%a a%re%m$%sere %mul%te";

            var calculateString = ReplaceString(inputString, charToReplace, newChar);
            Assert.AreEqual(expectedString, calculateString);
        }

        [TestMethod]
        public void NotFindCharToReplaceIntoAString()
        {
            String inputString = "#An#a a#re#m$%sere %mul#te";
            char charToReplace = 'D';
            char newChar = '%';
            String expectedString = "#An#a a#re#m$%sere %mul#te";

            var calculateString = ReplaceString(inputString, charToReplace, newChar);
            Assert.AreEqual(expectedString, calculateString);
        }

        [TestMethod]
        public void TryToReplaceACharIntoAnEmptyString()
        {
            String inputString = "";
            char charToReplace = 'D';
            char newChar = '%';
            string expectedString = "";

            var calculateString = ReplaceString(inputString, charToReplace, newChar);
            Assert.AreEqual(expectedString, calculateString);
        }

        [TestMethod]
        public void NLevelsOfPascalTriangle()
        {
            int n = 5;
            uint[,] expectedResult = new uint[6, 6] { { 1, 0, 0, 0, 0, 0 }, { 1, 1, 0, 0, 0, 0 }, { 1, 2, 1, 0, 0, 0 }, { 1, 3, 3, 1, 0, 0 }, { 1, 4, 6, 4, 1, 0 }, { 1, 5, 10, 10, 5, 1 } };
            var calculateResult = GeneratePascalTriangle(n);
            CollectionAssert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void FirstLevelOfPascalTriangle()
        {
            int n = 0;
            uint[,] expectedResult = new uint[1, 1] { { 1 } };
            var calculateResult = GeneratePascalTriangle(n);
            CollectionAssert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void SimplePrefixForm()
        {
            char[] inputString = { '/', '3', '4' };
            float expectedResult = 1;
            var calculateResult = GetResult(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        public static float GetResult(char[] inputString)
        {
            float result = 0;
            var operand=inputString[0];
            switch (operand)
            {
                case '+':
                    result = float.Parse(inputString[1].ToString()) + float.Parse(inputString[2].ToString());
                    break;
                case '-':
                    result = float.Parse(inputString[1].ToString()) - float.Parse(inputString[2].ToString());
                    break;
                case '*':
                    result = float.Parse(inputString[1].ToString()) * float.Parse(inputString[2].ToString());
                    break;
                case '/':
                    result = float.Parse(inputString[1].ToString()) / float.Parse(inputString[2].ToString());
                    break;

            }
            return result;

        }

        private static String ReverseString(string inputString)
        {
            if (inputString.Length == 0) return String.Empty;
            int lastPosition = inputString.Length - 1;
            return inputString[lastPosition] + ReverseString(inputString.Substring(0, lastPosition));
        }

        private static String ReplaceString(string inputString, char oldChar, char newChar)
        {
            if (inputString.Length == 0) return String.Empty;
            var substring = inputString.Substring(1, inputString.Length - 1);
            var proceesedString = ReplaceString(substring, oldChar, newChar);
            char firstChar = inputString[0];
            return (firstChar == oldChar) ? newChar + proceesedString : firstChar + proceesedString;
        }

        private uint[,] GeneratePascalTriangle(int totalLevelsNumber)
        {
            uint[,] resultOfTriangle = new uint[totalLevelsNumber + 1, totalLevelsNumber + 1];
            for (int levelNumber = 0; levelNumber <= totalLevelsNumber; levelNumber++)
            {
                GenerateOneLevelOfTriangle(levelNumber, ref resultOfTriangle);
            }
            return resultOfTriangle;
        }

        private static void GenerateOneLevelOfTriangle(int levelNumber, ref uint[,] resultOfTriangle)
        {
            for (int columnNumber = 0; columnNumber <= levelNumber; columnNumber++)
            {
                resultOfTriangle[levelNumber, columnNumber] = CalculateValueOfTriangleElement(levelNumber, columnNumber);
            }
        }

        public static uint CalculateValueOfTriangleElement(int lineNumber, int columnNumber)
        {
            if (columnNumber == 0 || lineNumber == columnNumber) return 1;
            var valueOfTriangle = CalculateValueOfTriangleElement(lineNumber - 1, columnNumber - 1) + CalculateValueOfTriangleElement(lineNumber - 1, columnNumber);
            return valueOfTriangle;
        }
    }
}

