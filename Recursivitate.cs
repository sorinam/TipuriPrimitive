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
        public void GeneratePascalTriangle()
        {
            int n = 5;
            uint[,] expectedResult = new uint[6, 6] { { 1, 0, 0, 0, 0, 0 }, { 1, 1, 0, 0, 0, 0 }, { 1, 2, 1, 0, 0, 0 }, { 1, 3, 3, 1, 0, 0 }, { 1, 4, 6, 4, 1, 0 }, { 1, 5, 10, 10, 5, 1 } };
            var calculateResult = PascalTriangle(n);
            CollectionAssert.AreEqual(expectedResult, calculateResult);
        }

        private static String ReverseString(string inputString)
        {
            if (inputString.Length > 0)
                return inputString[inputString.Length - 1] + ReverseString(inputString.Substring(0, inputString.Length - 1));
            else
                return inputString;
        }

        private static String ReplaceString(string inputString, char cchar, char rchar)
        {
            if (inputString.Length > 0)
            {
                var recursive = ReplaceString(inputString.Substring(1, inputString.Length - 1), cchar, rchar);
                return (inputString[0] == cchar) ? rchar + recursive : inputString[0] + recursive;
            }
            else
                return inputString;
        }

        private uint[,] PascalTriangle(int n)
        {
            uint[,] triangle = new uint[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    triangle[i, j] = Pascal(i, j);
                }
            }

            return triangle;
        }

        private static uint Pascal(int x, int y)
        {
            if (y == 0 || x == y)
            {
                return 1;
            }
            else
            {
                return Pascal(x - 1, y - 1) + Pascal(x - 1, y);
            }
        }
    }
}
