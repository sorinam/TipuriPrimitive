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
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void RegularPrefixExpression()
        {
            string[] inputString = { "*", "/", "*", "+", "56", "45", "45", "3", "0.75" };
            float expectedResult = 1136.25F;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void ExpressionWithoutNumbers()
        {
            string[] inputString = { "*", "/", "*", "+" };
            float expectedResult = -1;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void InvalidCharacterInExpression()
        {
            string[] inputString = { ")", "3", "4" };
            float expectedResult = -1;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void ComplexPrefixExpression()
        {
            string[] inputString = { "-", "*", "4", "+", "2", "1", "*", "2", "-", "3", "2" };
            float expectedResult = 10;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void AnotherComplexPrefixExpression()
        {
            string[] inputString = { "*", "3", "+", "2", "*", "2.5", "+", "3", "3" };
            float expectedResult = 51;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }
        [TestMethod]
        public void MoreComplexPrefixExpression()
        {
            string[] inputString = { "/","*","+", "7.2", "5", "+", "/", "3","4", "1", "/", "-", "52","7","+","3","2.5"};
            float expectedResult = 2.60945F;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult,0.01);
        }
        [TestMethod]
        public void IncompleteExpression()
        {
            string[] inputString = { "+", "2" };
            float expectedResult = -1;
            var calculateResult = CalculatorFromExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        [TestMethod]
        public void ExtractFirstSimpleExpression()
        {
            string[] inputString = { "-", "*", "4", "+", "2", "1", "*", "2", "-", "3", "2" }; 
            float expectedResult = 4;
            var calculateResult = GetFirstSimpleExpression(inputString);
            Assert.AreEqual(expectedResult, calculateResult);
        }

        private static float CalculatorFromExpression(string[] inputString)
        {
            if (inputString.Length <= 3)
            {
                return SimpleExpression(inputString);
            }
            else
            {
                int index = GetFirstSimpleExpression(inputString);
                if (index < 0)
                {
                    return -1;
                }
                var partialResult = CalculateSimpleExpression(inputString, index);
                GenerateNewExpression(ref inputString, index - 1, Convert.ToString(partialResult));
                return CalculatorFromExpression(inputString);
            }
        }


        private static int GetFirstSimpleExpression(string[] inputString)
        {
            int index = GetFirstNumberInString(inputString);
            if (index > 0 && index < inputString.Length - 1)
            {
                float value;
                bool IsNumber = float.TryParse(inputString[index + 1], out value);
                if (IsNumber)
                {
                    return index;
                }
                else
                {
                    string[] newSubtring = new string[inputString.Length - index - 1];
                    Array.Copy(inputString, index + 1, newSubtring, 0, inputString.Length - index - 1);
                    return index + 1 + GetFirstSimpleExpression(newSubtring);
                }
            }
            else
                return -1;
        }

        private static bool ValidateExpression(string[] inputString)
        {
            if (!("+-*/".Contains(inputString[0])))
            {
                return false;
            }
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

        private static float CalculateSimpleExpression(string[] inputString, int index)
        {
            string[] basicString = { inputString[index - 1], inputString[index], inputString[index + 1] };
            return SimpleExpression(basicString);
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
            bool isValidExpression = ValidateExpression(inputString);
            if (isValidExpression)
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
                        return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
