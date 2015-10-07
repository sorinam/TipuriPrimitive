using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
      [TestClass]
    public class EncryptDecrypt
    {
        public const string specialChars = "!+-&%*()";
        public static string resultOfEncryption="";
        public static string resultOfDecryption = "";

        [TestMethod]
        public void EncryptTextNeedMoreRandomLetters()
        {
            string inputString = "nicaieri nu e ca acasa";
            string outputString = "neeaircsciaaana+iucx";
            uint numberOfColumns = 4;
            uint numberOfRows;
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            int indexOfSpecialChar = GetPositionOfSpecialCharInString(resultOfEncryption);

            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            Assert.AreEqual(outputString.IndexOf('+'), indexOfSpecialChar, "Expected special char position: " + outputString.IndexOf('&') + " Result special char position: " + indexOfSpecialChar);
            Assert.AreEqual(outputString.Substring(0, indexOfSpecialChar), resultOfEncryption.Substring(0, indexOfSpecialChar));
            Assert.AreEqual(outputString.Substring(indexOfSpecialChar+1,(int)numberOfColumns-1), resultOfEncryption.Substring(indexOfSpecialChar+1, (int)numberOfColumns-1));

        }

       [TestMethod]
        public void EncryptTextNeedOnlyOneSpecialChar()
        {
            string inputString = " Sanda, sa stii ca nicaieri, nu e ca acasa !";
            string outputString = "Sataaicaasininasnaiieuaadsccrec&";
            uint numberOfColumns = 8;
            uint numberOfRows;
           
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);
            int indexOfSpecialChar = GetPositionOfSpecialCharInString(resultOfEncryption);

            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            Assert.AreEqual(outputString.IndexOf('&'), indexOfSpecialChar, "Expected special char position: " + outputString.IndexOf('&') + " Result special char position: " + indexOfSpecialChar);
            Assert.AreEqual(outputString.Substring(0, indexOfSpecialChar), resultOfEncryption.Substring(0, indexOfSpecialChar));
            
        }

        [TestMethod]
        public void EncryptTextNoNeededRandomLetters()
        {
            string inputString = " Sorina, sa stii ca nicaieri, nu e ca acasa !";
            string outputString = "Snsccrecoataaicarsininasiaiieuaa";
            uint numberOfColumns = 8;
            uint numberOfRows;

            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);

            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            Assert.AreEqual(outputString, resultOfEncryption);

        }

        [TestMethod]
        public void EncryptTextNullInputString()
        {
            string inputString = "";
            uint numberOfColumns = 8;
            uint numberOfRows;
          
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);

            Assert.AreEqual(0, (int)numberOfRows);
            Assert.AreEqual("", resultOfEncryption);
        }

        [TestMethod]
        public void EncryptTextOnlyOneColumn()
        {
            string inputString = "nicaieri nu! e asa bine $ ca & acasa !";
            string outputString = "nicaierinueasabinecaacasa";
            uint numberOfColumns = 1;
            uint numberOfRows;       
               
            resultOfEncryption = Encrypt(inputString, numberOfColumns, out numberOfRows);

            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, resultOfEncryption.Length, "Expected Output length : " + outputString.Length + " Calculate  Output length : " + numberOfRows);
            Assert.AreEqual(outputString, resultOfEncryption);
        }

        [TestMethod]
        public void DecryptTextWithMoreRandomLetters()
        {
            string inputString = "neeaircsciaaana+iucx";
            string outputString = "nicaierinuecaacasa";
            uint numberOfColumns = 4;
            uint numberOfRows;
            int indexOfSpecialChar;

            resultOfDecryption = Decrypt(inputString, numberOfColumns, out numberOfRows);
            indexOfSpecialChar = GetIndexOfNonLetterCharacter(resultOfDecryption);

            Assert.IsTrue((inputString.Length % numberOfColumns == 0), "Invalid length of input string or number of columns");
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, indexOfSpecialChar, "Invalid index of special char");
            Assert.AreEqual(outputString, resultOfDecryption.Substring(0, indexOfSpecialChar));

        }
              
        [TestMethod]
        public void DecryptTextWithOnlyOneSpecialChar()
        {
            string inputString = "Sataaicaasininasnaiieuaadsccrec+";
            string outputString = "Sandasastiicanicaierinuecaacasa";
            uint numberOfColumns = 8;
            uint numberOfRows;
            int indexOfSpecialChar;

            resultOfDecryption = Decrypt(inputString, numberOfColumns, out numberOfRows);
            indexOfSpecialChar = GetIndexOfNonLetterCharacter(resultOfDecryption);

            Assert.IsTrue((inputString.Length % numberOfColumns == 0), "Invalid length of input string or number of columns");
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString.Length, indexOfSpecialChar, "Invalid index of special char");
            Assert.AreEqual(outputString, resultOfDecryption.Substring(0, indexOfSpecialChar));

        }

        [TestMethod]
        public void DecryptTextWithoutRandomLetters()
        {
            string inputString = "Snsccrecoataaicarsininasiaiieuaa";
            string outputString = "Sorinasastiicanicaierinuecaacasa";
            uint numberOfColumns = 8;
            uint numberOfRows;

            resultOfDecryption = Decrypt(inputString, numberOfColumns, out numberOfRows);

            Assert.IsTrue((inputString.Length % numberOfColumns == 0), "Invalid length of input string or number of columns");
            Assert.IsTrue(numberOfRows > 0, "There are no data");
            Assert.AreEqual(outputString, resultOfDecryption);

        }

        private static string Decrypt(string inputString, uint numberOfColumns, out uint numberOfRows)
        {
             if (inputString != null)
            {
                numberOfRows = (uint)(inputString.Length / numberOfColumns);
                return GenerateOutputStringForDecryption(inputString, numberOfColumns, numberOfRows);
            }
            else
            {
                numberOfRows = 0;
                return "";
            }
         
        }

        private static string Encrypt(string inputString, uint numberOfColumns, out uint numberOfRows)
        {
           if (inputString != null)
            {               
                string textOnlyWithLetters = RemoveNonLetterCharacters(inputString);
                numberOfRows = CalculateNumberOfRows(textOnlyWithLetters.Length, numberOfColumns);
                return GenerateOutputStringForEncryption(textOnlyWithLetters, numberOfColumns, numberOfRows);
            }
            else
            {
                numberOfRows = 0;
                return "";
            }
          
        }

        private static string GenerateOutputStringForEncryption(string inputString, uint numberOfColumns, uint numberOfRows)
        {
            string outString = "";
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    int index = PositionOfCharInEncrypedString(i, j, numberOfRows);
                    outString += SetCharInEncyptedString(inputString,index,i,j,numberOfRows);
                }
            }
            return outString;
        }

        private static int PositionOfCharInEncrypedString(int rowNumber, int columnNumber, uint numberOfRows)
        {
            return ((columnNumber - 1) * (int)numberOfRows + rowNumber - 1);
        }

        private static char SetCharInEncyptedString(string inputString, int index, int noRow, int noColumn, uint numberOfRows)
        {
            if (index >= inputString.Length)
            {
                return SetRandomChar(noRow, noColumn, numberOfRows, inputString.Length);
            }
            else
            {
                return inputString[index];
            }
        }

        private static char SetRandomChar(int i, int j, uint numberOfRows, int length)
        {         
            if (PositionOfCharInEncrypedString(i, j, numberOfRows) == length)
            {
                return GetRandomChar();
            }
            else
            {
                return GetRandomLetter();
            }
         }

        private static string GenerateOutputStringForDecryption(string inputString, uint numberOfColumns, uint numberOfRows)
        {
            string outString = "";
            for (int j = 0; j < numberOfColumns; j++)
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    outString += inputString[GetPositionOfCharInEncrypedString(numberOfColumns, j, i)];
                }

            }
            return outString;
        }

        private static int GetPositionOfCharInEncrypedString(uint numberOfColumns, int columnNumber, int rowNumber)
        {
            return columnNumber + rowNumber * (int)numberOfColumns;
        }

        private static string RemoveNonLetterCharacters(string text)
        {
            string newText = "";
            foreach (char c in text)
            {
                if (IsLetter(c))
                {
                    newText += c;
                }
            }
            return newText;
        }

        static bool IsLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        private static bool IsSpecialChar(char c)
        {
            return (specialChars.IndexOf(c) > 0) ;
                
        }

        private static char GetRandomLetter()
        {
            Random random = new Random();
            int num = random.Next(0, 26);
            char letter = (char)('a' + num);
            return letter;
        }
        
        private static char GetRandomChar()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, specialChars.Length);
            return specialChars[randomNumber];
        }

        private static uint CalculateNumberOfRows(int stringLength, uint columnsNumber)
        {
            decimal noOfRows = (decimal)stringLength / columnsNumber;
            return (uint)Math.Ceiling(noOfRows);
        }

        private static int GetPositionOfSpecialCharInString(string StringToSearch)
        {
            for (int i = 0; i < specialChars.Length; i++)
            {
                if (GetIndexOfCharInString(StringToSearch,(char)specialChars[i]) > 0)
                {
                    return GetIndexOfCharInString(StringToSearch, (char)specialChars[i]);
                }
            }
           return -1;

    }

        private static int GetIndexOfCharInString(string stringToSearch,char c)
        {
            return stringToSearch.IndexOf(c);

        }

        private static int GetIndexOfNonLetterCharacter(string stringToSearch)
        {
            for (int i = 0; i < stringToSearch.Length; i++)
            {
                if (!(IsLetter((char)stringToSearch[i])))
                {
                    return i;
                }
            }
            return -1;
        }
    }
 }