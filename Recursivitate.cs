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
            String  inputString = "mama are mere";
            String outputString = "erem era amam";
            var calculateString = ReverseString(inputString);
            Assert.AreEqual(calculateString, outputString);
		}

        private String ReverseString(string inputString)
        {
            if (inputString.Length > 0)
                return inputString[inputString.Length - 1] + ReverseString(inputString.Substring(0, inputString.Length - 1));
            else
                return inputString;            
        }
    }
}
