using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class EncryptDecrypt
    {
       [TestMethod]
        public void EncryptText_RemoveOnlyWhiteSpaces()
        {
            string inputString =  "nicaieri nu e ca acasa";
            string[] outputString = { "neea","ircs","ciaa","anax","iucx" };
            uint numberOfColumns = 4;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns,out numberOfRows);
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, (int)numberOfRows, "Expected rows: " + outputString.Length + " Calculate number of rows: " + numberOfRows);
            for (int i = 0; i < numberOfRows; i++)
            {
                bool testResult = (outputString[i] == resultOfEncryption[i]) || outputString[i].StartsWith(resultOfEncryption[i].Substring(0, (int)numberOfColumns - 1));
                Assert.IsTrue(testResult, "Expected: " + outputString[i] + " Returned:" + resultOfEncryption[i]);
            }
        }
        [TestMethod]
        public void EncryptText_RemoveAllCharactersExceptLetters()
        {
            string inputString = " Sanda, sa stii ca nicaieri, nu e ca acasa !";
            string[] outputString = {"Sataaica", "asininas", "naiieuaa", "dsccrecE" };
            uint numberOfColumns = 8;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns,out numberOfRows);
            Assert.IsTrue(numberOfRows > 0,"There are no data");
            Assert.AreEqual(outputString.Length, (int)numberOfRows, "Expected rows: " + outputString.Length + " Calculate number of rows: " + numberOfRows);
            for (int i = 0; i< numberOfRows; i++)
            {
                bool testResult = (outputString[i] == resultOfEncryption[i]) || outputString[i].StartsWith(resultOfEncryption[i].Substring(0, (int)numberOfColumns - 1));
                Assert.IsTrue(testResult, "Expected: " + outputString[i] + " Returned:" + resultOfEncryption[i]);
            }
          
        }
        [TestMethod]
        public void EncryptText_NullInputString()
        {
            string inputString = "";
            uint numberOfColumns = 8;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            Assert.AreEqual(0, (int)numberOfRows);
         }
        [TestMethod]
        public void EncryptText_OnlyOneColumn()
        {
            string inputString = "nicaieri nu!";
            string[] outputString = { "n", "i","c", "a", "i", "e", "r", "i", "n", "u" };
            uint numberOfColumns = 1;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, (int)numberOfRows, "Expected rows: " + outputString.Length + " Calculate number of rows: " + numberOfRows);
            for (int i = 0; i < numberOfRows; i++)
            {
                bool testResult = (outputString[i] == resultOfEncryption[i]) ;
                Assert.IsTrue(testResult, "Expected: " + outputString[i] + " Returned:" + resultOfEncryption[i]);
            }
        }
        private string[] Encrypt(string inputString, uint numberOfColumns, out uint numberOfRows)
        {
            string[] OutputString;
            if (inputString != null)
            {
                string textWithoutWhiteSpaces = TrimWhiteSpaces(inputString);
                string textOnlyWithLetters = RemoveOtherCharacters(textWithoutWhiteSpaces);
                int newLength = textOnlyWithLetters.Length;
                uint NumberOfRows = CalculateNumberOfRows(newLength, numberOfColumns);
                char[,] matrixOfChars = FillMatrixWithChars(textOnlyWithLetters, NumberOfRows, numberOfColumns);
                OutputString = GetStringsFromMatrix(matrixOfChars, NumberOfRows, numberOfColumns);
                numberOfRows = NumberOfRows;
              }
            else
            {
                numberOfRows = 0;
                OutputString=new string[0];
             }
            return OutputString;
       }

        private string RemoveOtherCharacters(string text)
        {
            string newText = "";
            foreach (char c in text)
             {
                if (IsLetter(c))
                    { newText += c; }              
              }
            return newText;
       }
        bool IsLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
        private string[] GetStringsFromMatrix(char[,] matrixOfChars, uint numberOfRows, uint numberOfColumns)
        {
            //create output string - read matrix from rows
            string[] OutputString = new string[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                OutputString[i] = "";
                for (int j = 0; j < numberOfColumns; j++)
                {
                    OutputString[i] += matrixOfChars[i, j];
                }
            }
            return OutputString;
        }

        private char[,] FillMatrixWithChars(string textWithoutWhiteSpaces, uint numberOfRows, uint numberOfColumns)
        {
            char[,] matrix = new char[numberOfRows, numberOfColumns];
            int l = 0;
            int lastrow = 0;
            
                for (int j = 0; j < numberOfColumns; j++)
                {
                for (int i = 0; i < numberOfRows; i++)
                {
                    if (l < textWithoutWhiteSpaces.Length)
                    {
                        matrix[i, j] = textWithoutWhiteSpaces[l];
                        l++;
                     }
                    else
                    {
                        lastrow = i;
                        i = (int)numberOfRows;
                    }
                }

                }
            //fill with random chars;
            for (int newi = lastrow; newi < numberOfRows; newi++)
            {
                matrix[newi, numberOfColumns-1] = GetRandomLetter();
            }
            return matrix;
            
        }

        private static char GetRandomLetter()
        {   Random random = new Random();
            int num = random.Next(0, 26); 
            char letter = (char)('a' + num);
            return letter;
        }
        private uint CalculateNumberOfRows(int stringLength,uint columnsNumber )
        {
            decimal nbOfRows = (decimal)stringLength / columnsNumber;
            uint numberOfRows = (uint)Math.Ceiling(nbOfRows);
            return numberOfRows;
        }
        private string TrimWhiteSpaces(string inputString)
        {
            string[] words = inputString.Split();
            string result = "";
            foreach (string word in words) { result += word; }
            return result;
        }
    }

      
}