using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Calculator
    {
        [TestMethod]
        public void CalculateValueFromSimplePrefixForm()
        {
            string[] inputString = { "/", "3", "4" };
            float expectedResult = 0.75F;
            var calculateResult = CalculatorFromPrefixExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]

        public void CalculatateValueFromPrefixForm()
        {
            string[] inputString = { "*", "/", "*", "+", "56", "45", "45", "3", "0.75" };
            float expectedResult = 1136.25F;
            var calculateResult = CalculatorFromPrefixExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }
        [TestMethod]

        public void CalculateValueFromPrefixFormWithoutNumbers()
        {
            string[] inputString = { "*", "/", "*", "+" };
            float expectedResult = -1;
            var calculateResult = CalculatorFromPrefixExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void UseInvalidOperatorInPrefixForm()
        {
            string[] inputString = { ")", "3", "4" };
            float expectedResult = 0;
            var calculateResult = CalculatorFromPrefixExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void CalculateValueFromComplexPrefixForm()
        {
            string[] inputString = { "+", "+", "2", "3", "*", "/", "*", "4", "5", "2", "3" };
            float expectedResult = 35;
            var calculateResult = CalculatorFromPrefixExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        private static float CalculatorFromPrefixExpression(string[] inputString)
        {
            if (inputString.Length == 3)
            {
                return SimpleExpression(inputString);
            }
            else
            {
                int index = GetFirstNumberInString(inputString);
                if (index < 0) return -1;
                float value;
                bool isNumber = float.TryParse(inputString[index + 1], out value);
                if (isNumber)
                {
                    inputString = CalculateDeepValueAndGenerateNewExpression(inputString, index);
                    return CalculatorFromPrefixExpression(inputString);
                }
                else
                {
                    string[] rightExpression = ExtractRightPrefixExpression(inputString, index);
                    var valueOfRightExpression = CalculatorFromPrefixExpression(rightExpression).ToString();
                    string[] leftExpression = ExtractLeftPrefixExpression(inputString, index);
                    leftExpression[index + 1] = valueOfRightExpression;
                    return CalculatorFromPrefixExpression(leftExpression);
                }
            }

        }
        private static string[] ExtractRightPrefixExpression(string[] inputString, int index)
        {
            string[] subString = new string[inputString.Length - index - 1];
            Array.Copy(inputString, index + 1, subString, 0, inputString.Length - index - 1);
            return subString;
        }
        private static string[] ExtractLeftPrefixExpression(string[] inputString, int index)
        {
            string[] subString = new string[index + 2];
            Array.Copy(inputString, subString, index + 1);
            return subString;
        }
        private static string[] CalculateDeepValueAndGenerateNewExpression(string[] inputString, int index)
        {
            var partialResult = CalculateSimpleExpression(inputString, index);
            ReplaceCalculateValueinExpression(ref inputString, index - 1, Convert.ToString(partialResult));
            return inputString;
        }
        private static float CalculateSimpleExpression(string[] inputString, int index)
        {
            string[] simplePrefixString = { inputString[index - 1], inputString[index], inputString[index + 1] };
            return SimpleExpression(simplePrefixString);
        }
        private static void ReplaceCalculateValueinExpression(ref string[] inputString, int indexofoperator, string newResult)
        {
            inputString[indexofoperator] = newResult;
            for (int i = indexofoperator + 1; i < inputString.Length - 2; i++)
            {
                inputString[i] = inputString[i + 2];
            }
            Array.Resize(ref inputString, inputString.Length - 2);
        }

        private static int GetFirstNumberInString(string[] inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                float value;
                if (float.TryParse(inputString[i], out value))
                {
                    return i;
                }
            }
            return -1;
        }

        public static float SimpleExpression(string[] inputString)
        {
            var operand = inputString[0];
            float firstNumber = float.Parse(inputString[1].ToString());
            float secondNumber = float.Parse(inputString[2].ToString());

            switch (operand)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                default:
                    return 0;
            }

        }
    }
}
