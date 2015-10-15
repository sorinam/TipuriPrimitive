using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TipuriPrimitive
{
    [TestClass]
    public class Calculator
    {
        [TestMethod]
        public void SimplePrefixExpression()
        {
            string[] inputString = { "/", "3", "4" };
            float expectedResult = 0.75F;
            Assert.IsTrue(ValidateExpression(inputString), "Invalid Expression");
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void RegularPrefixExpression()
        {
            string[] inputString = { "*", "/", "*", "+", "56", "45", "45", "3", "0.75" };
            float expectedResult = 1136.25F;
            Assert.IsTrue(ValidateExpression(inputString), "Invalid Expression");
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void ExpressionWithoutNumbers()
        {
            string[] inputString = { "*", "/", "*", "+" };
            float expectedResult = -1;
            Assert.IsTrue(ValidateExpression(inputString), "Invalid Expression");
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }
       
        [TestMethod]
        public void InvalidCharacterInExpression()
        {
            string[] inputString = { ")", "3", "4" };
            Assert.IsFalse(ValidateExpression(inputString), "Invalid Expression");
         }

        [TestMethod]
        public void ComplexPrefixExpression()
        {
            string[] inputString = { "+", "+", "2", "3", "*", "/", "*", "4", "5", "2", "3" };
            float expectedResult = 35;
            Assert.IsTrue(ValidateExpression(inputString), "Invalid Expression");
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void IncompleteExpression()
        {
            string[] inputString = { "+", "2" };
            Assert.IsFalse(ValidateExpression(inputString),"Invalid Expression");
        }

        private static float CalculatorFromExpression(string[] inputString)
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
                bool isNumberNextString = float.TryParse(inputString[index + 1], out value);

                if (isNumberNextString)
                {
                    inputString = CalculateCellValueAndGenerateNewExpression(inputString, index);
                    return CalculatorFromExpression(inputString);
                }
                else
                {
                    string[] rightExpression = ExtractRightExpression(inputString, index);
                    var valueOfRightExpression = CalculatorFromExpression(rightExpression).ToString();
                    string[] leftExpression = ExtractLeftPrefixExpression(inputString, index);
                    leftExpression[index + 1] = valueOfRightExpression;
                    return CalculatorFromExpression(leftExpression);
                }
            }

        }


        private static bool ValidateExpression(string[] inputString)
        {
          
            if (inputString.Length < 3)
                return false;
            foreach (string element in inputString)
            {
                if (!IsNumberOrOperator(element)) return false;
            }
            return true;

        }

        private static bool IsNumberOrOperator(string element)
        {
            string operators = "+-*/";
            float value;
            {
                bool IsNumber = float.TryParse(element, out value);
                if (!IsNumber)
                {
                    if (!operators.Contains(element))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
        private static string[] ExtractRightExpression(string[] inputString, int index)
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

        private static string[] CalculateCellValueAndGenerateNewExpression(string[] inputString, int index)
        {
            var partialResult = CalculateSimpleExpression(inputString, index);
            GenerateNewExpression(ref inputString, index - 1, Convert.ToString(partialResult));
            return inputString;
        }

        private static float CalculateSimpleExpression(string[] inputString, int index)
        {
            string[] simplePrefixString = { inputString[index - 1], inputString[index], inputString[index + 1] };
            return SimpleExpression(simplePrefixString);
        }

        private static void GenerateNewExpression(ref string[] inputString, int indexofoperator, string newResult)
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
