using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Resources;

namespace Calculator
{
    public class Processor
    {
        private readonly Operation _operation;

        public Processor()
        {
            _operation = new Operation();
        }

        public string CheckExpression(string buttonText, string expression)
        {
            if (buttonText == Constants.Dot && (expression.Contains(Constants.Dot) || expression.Length == 0))
            {
                return string.Empty;
            }
            return buttonText;
        }

        private static double? Parse(string num)
        {
            var boolResult = double.TryParse(num, out var result);
            if (boolResult == false)
            {
                return null;
            }
            return result;
        }

        private static string GetBackSpaceNum(string expressionText)
        {
            return expressionText != string.Empty ? expressionText.Substring(0, expressionText.Length - 1) : string.Empty;
        }

        private string CancelCommand()
        {
            _operation.Clear();
            return string.Empty;
        }

        private void EqualCommand(ref string expressionText)
        {
            _operation.SecondOperand = Parse(expressionText);
            expressionText = _operation.GetResult()?.ToString() ?? expressionText;
            _operation.FirstOperand = _operation.Result;
        }

        private string DefaultCommand(string operat, string expressionText)
        {
            if (operat == Constants.Minus && _operation.FirstOperand == null)
            {
                expressionText += Constants.Minus;
                return expressionText;
            }
            _operation.FirstOperand = Parse(expressionText);
            _operation.Operat = operat;
            expressionText = string.Empty;
            return expressionText;
        }

        public string GetResult(string operat, string expressionText)
        {
            switch (operat)
            {
                case Constants.Cancel:
                    expressionText = CancelCommand();
                    break;
                case Constants.BackSpase:
                    expressionText = GetBackSpaceNum(expressionText);
                    break;
                case Constants.Equal:
                    EqualCommand(ref expressionText);
                    break;
                default:
                    expressionText = DefaultCommand(operat, expressionText);
                    break;
            }
            return expressionText;
        }

        private class Operation
        {
            public double? Result;
            public double? FirstOperand;
            public double? SecondOperand;
            public string Operat;

            public double? GetResult()
            {
                switch (Operat)
                {
                    case Constants.Plus:
                        Result = FirstOperand + SecondOperand;
                        break;
                    case Constants.Minus:
                        Result = FirstOperand - SecondOperand;
                        break;
                    case Constants.Division:
                        Result = FirstOperand / SecondOperand;
                        break;
                    case Constants.Multiplication:
                        Result = FirstOperand * SecondOperand;
                        break;
                }

                return Result;
            }

            public void Clear()
            {
                Result = null;
                FirstOperand = null;
                SecondOperand = null;
                Operat = null;
            }
        }
    }
}
