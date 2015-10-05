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
            string inputString = "nicaieri nu e ca acasa";
            string[] outputString = { "neea","ircs","ciaa","anax","iucx" };
            uint numberOfColumns = 4;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns,out numberOfRows);
             for (int j=0;j<numberOfRows;j++)
             {
                bool testResult = (outputString[j] == resultOfEncryption[j]) || (outputString[j].Contains(resultOfEncryption[j].Substring(0, (int)numberOfColumns - 1)));
                Assert.IsTrue(testResult,"Expected: "+ outputString[j]+" Returned:"+ resultOfEncryption[j]);
             }         
          }
        [TestMethod]
        public void EncryptText_RemoveAllCharactersExceptLetters()
        {
            string inputString = " Nicaieri, nu e ca acasa !";
            string[] outputString = { "Neea", "ircs", "ciaa", "anai", "iuci" };
            uint numberOfColumns = 4;
            uint numberOfRows;
            string[] resultOfEncryption = new string[numberOfColumns];
            resultOfEncryption = Encrypt(inputString, numberOfColumns,out numberOfRows);
            for (int j = 0; j < numberOfRows; j++)
            {
                bool testResult = (outputString[j] == resultOfEncryption[j]) || (outputString[j].Contains(resultOfEncryption[j].Substring(0, (int)numberOfColumns - 1)));
                Assert.IsTrue(testResult, "Expected: " + outputString[j] + " Returned:" + resultOfEncryption[j]);
            }
          
        }
        private string[] Encrypt(string inputString, uint numberOfColumns, out uint numberOfRows)
        {
            string textWithoutWhiteSpaces = TrimWhiteSpaces(inputString);
            string textOnlyWithLetters = RemoveOtherCharacters(textWithoutWhiteSpaces);
            int newLength = textOnlyWithLetters.Length;
            uint NumberOfRows = CalculateNumberOfRows(newLength, numberOfColumns);
            char[,] matrixOfChars = FillMatrixWithChars(textOnlyWithLetters, NumberOfRows, numberOfColumns);
            string[] OutputString = GetStringsFromMatrix(matrixOfChars, NumberOfRows, numberOfColumns);
            numberOfRows = NumberOfRows;
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