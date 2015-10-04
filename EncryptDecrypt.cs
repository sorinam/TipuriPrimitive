using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class EncryptDecrypt
    {
        [TestMethod]
        public void EncryptText()
        {
            string InputString = "nicaieri nu e ca acasa";
            uint NumberOfColumns = 4;
            string[] ExpectedOutputString = { "neea", "ircs", "ciaa", "ana", "iuc" };
            Assert.AreEqual(ExpectedOutputString, Encrypt(InputString, NumberOfColumns)); }

        private string[] Encrypt(string inputString, uint numberOfColumns)
        {
            string textWithoutWhiteSpaces = TrimAndFindWhiteSpaces(inputString);
            int newLength = textWithoutWhiteSpaces.Length;
            uint numberOfRows = CalculateNumberOfRows(newLength, numberOfColumns);
            char[,] matrix = new char[numberOfRows-1, numberOfColumns-1];
            int l = 0;
            int lastrow = 0;
            for (int j=0;j<numberOfColumns; j++)
            {
                for(int i=0;i<numberOfRows;i++)
                {
                    matrix[i, j] = textWithoutWhiteSpaces[l];
                    l++; 
                    lastrow = i;
                }
            
            }
            //fill with random chars;
            for (int newi= lastrow;newi<numberOfRows;newi++)
            {
                matrix[newi, numberOfColumns] = GetRandomLetter();
            }
            //create output string - read matrix from rows
            string[] OutputString = new string[numberOfRows];
            for (int i=0;i<numberOfRows;i++)
            {
                OutputString[i] = "";
                for (int j=0;j<numberOfColumns;j++)
                {
                    OutputString[i] += matrix[i, j];
                }
             }
            return OutputString;
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
        private string TrimAndFindWhiteSpaces(string inputString)
        {
            string[] words = inputString.Split();
            string result = "";
            foreach (string word in words) { result += word; }
            return result;
        }
    }

      
}