using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class EncryptDecrypt
    {
       [TestMethod]
        public void EncryptTextRemoveOnlyWhiteSpaces()
        {
            string inputString =  "nicaieri nu e ca acasa";
            string outputString = "neeaircsciaaana&iucx";
            uint numberOfColumns = 4;
            uint numberOfRows;
            string resultOfEncryption = "";
            resultOfEncryption = Encrypt(inputString, numberOfColumns,out numberOfRows);
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            int indexOfSpecialChar = 0;
            Assert.AreEqual(outputString.IndexOf('&'), resultOfEncryption.IndexOf('&'), "Expected & position: " + outputString.IndexOf('&') + " Result & position: " + resultOfEncryption.IndexOf('&'));
            indexOfSpecialChar = outputString.IndexOf('&');
            //compare result until first special char
            Assert.AreEqual(outputString.Substring(0, indexOfSpecialChar), resultOfEncryption.Substring(0, indexOfSpecialChar));

           }
    
        [TestMethod]
        public void EncryptTextRemoveAllCharactersExceptLetters()
        {
            string inputString = " Sanda, sa stii ca nicaieri, nu e ca acas !";
            string outputString = "Sataaicaasininasnaiieua&dsccrech";
            uint numberOfColumns = 8;
            uint numberOfRows;
            string resultOfEncryption = "";
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            int indexOfSpecialChar = 0;
            Assert.AreEqual(outputString.IndexOf('&'), resultOfEncryption.IndexOf('&'),"Expected & position: "+ outputString.IndexOf('&')+" Result & position: "+ resultOfEncryption.IndexOf('&'));
            indexOfSpecialChar = outputString.IndexOf('&');
            //compare result until first special char
            Assert.AreEqual(outputString.Substring(0, indexOfSpecialChar), resultOfEncryption.Substring(0, indexOfSpecialChar));
        }

        [TestMethod]
        public void EncryptTextNullInputString()
        {
            string inputString = "";
            uint numberOfColumns = 8;
            uint numberOfRows;
            string resultOfEncryption = "";
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            Assert.AreEqual(0, (int)numberOfRows);
         }

        [TestMethod]
        public void EncryptTextOnlyOneColumn()
        {
            string inputString = "nicaieri nu!";
            string[] outputString = { "n", "i","c", "a", "i", "e", "r", "i", "n", "u" };
            uint numberOfColumns = 1;
            uint numberOfRows;
            string resultOfEncryption = "";
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            Assert.AreEqual(outputString, resultOfEncryption);
        }

        private string Encrypt(string inputString, uint numberOfColumns, out uint numberOfRows)
        {
            string outputString;
            if (inputString != null)
            {
                string textWithoutWhiteSpaces = TrimWhiteSpaces(inputString);
                string textOnlyWithLetters = RemoveOtherCharacters(textWithoutWhiteSpaces);
                int newLength = textOnlyWithLetters.Length;
                uint numberOfRowsN = CalculateNumberOfRows(newLength, numberOfColumns);
                outputString = GenerateOutputStringForEncryption(textOnlyWithLetters, numberOfColumns, numberOfRowsN);
                numberOfRows = numberOfRowsN;
              }
            else
            {
                numberOfRows = 0;
                outputString="";
             }
            return outputString;
       }

        private string GenerateOutputStringForEncryption(string inputString, uint numberOfColumns, uint numberOfRows)
        {
            string outString= "";
            for(int i=1;i<=numberOfRows;i++)
            {
                for (int j = 1; j <= numberOfColumns;j++)
                {
                    if( ((j - 1) * (int)numberOfRows + i - 1) >= inputString.Length)
                    {  
                        //first random char will be "&"
                        if (((j - 1) * (int)numberOfRows + i - 1) == inputString.Length)
                        { outString += "&"; }
                        else
                        {//fill with random letters
                            outString += GetRandomLetter();
                        }
                    }
                    else
                    {
                    outString += inputString[(j - 1) * (int)numberOfRows + i - 1];
                    }
                }

            }
            return outString;
        }

        private string GenerateOutputStringForDecryption(string inputString, uint numberOfColumns, uint numberOfRows)
        {
            string outString = "";
            for (int j = 0; j < numberOfColumns; j++)
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    outString += inputString[j + i * (int)numberOfColumns];
                }

            }
            return outString;
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