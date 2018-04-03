using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Operation
    {
        public double? result;
        public double? firstOperand;
        public double? secondOperand;
        public string operat;

        public double? GetResult()
        {
            switch (operat)
            {
                case "+": result = firstOperand + secondOperand; break;
                case "-": result = firstOperand - secondOperand; break;
                case "/": result = firstOperand / secondOperand; break;
                case "X": result = firstOperand * secondOperand; break;
            }
            return result;
        }

        public void Clear()
        {
            result = null;
            firstOperand = null;
            secondOperand = null;
            operat = null;
        }
    }

    public class Processor
    {
        Operation operation;

        public Processor()
        {
            operation = new Operation();
        }

        public string CheckExpression(string buttonText, string expression)
        {
            if (buttonText == "." && (expression.Contains(".") || expression.Length == 0))
            {
                return "";
            }
            return buttonText;
        }

        private double? Parse(string num)
        {
            bool boolResult = double.TryParse(num, out double result);
            if (boolResult == false)
            {
                return null;
            }
            return result;
        }

        private string GetBackSpaceNum(string expressionText)
        {
            if (expressionText != "")
            {
                return expressionText.Substring(0, expressionText.Length - 1);
            }
            return "";
        }

        public string GetResult(string operat, string expressionText)
        {
            switch (operat)
            {
                case "C":
                    expressionText = "";
                    operation.Clear();
                    break;
                case "Back":
                    expressionText = GetBackSpaceNum(expressionText);
                    break;
                case "=":
                    operation.secondOperand = Parse(expressionText);
                    expressionText = operation.GetResult()?.ToString() ?? expressionText;
                    operation.firstOperand = operation.result;
                    break;
                default:
                    if(operat == "-" && operation.firstOperand == null)
                    {
                        expressionText += "-";
                    }
                    else
                    {
                        operation.firstOperand = Parse(expressionText);
                        operation.operat = operat;
                        expressionText = "";
                    }
                    break;
            }
            return expressionText;
        }
    }
}
