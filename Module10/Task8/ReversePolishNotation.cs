using System;
using System.Linq;

namespace Module10.Task8
{
    public static class ReversePolishNotation
    {
        private static readonly char[] _operators = new char[] { '+', '-', '*', '/' };

        public static int Calculate(string expression)
        {
            if (expression?.Length == 0)
            {
                return 0;
            }

            CheckString(expression);            
            int left = 0;
            int right = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (_operators.Contains(expression[i]))
                {
                    bool isFirstDigit = true;
                    int index = i;
                    int rightBorder = i;
                    int leftBorder = 0;
                    for (int j = rightBorder - 2; j >= 0; j--)
                    {
                        if (expression[j] == ' ' && isFirstDigit)
                        {
                            isFirstDigit = false;
                            right = int.Parse(expression[j..(index-1)]);
                            index = j;
                        }
                        else if ((expression[j] == ' ' || j == 0) && !isFirstDigit)
                        {
                            left = int.Parse(expression[j..index]);
                            leftBorder = j == 0 ? -1 : j;
                            break;
                        }
                    }

                    int result = expression[i] switch
                    {
                        '+' => left + right,
                        '-' => left - right,
                        '*' => left * right,
                        _ => left / right
                    };

                    expression = expression[..(leftBorder + 1)] + result + expression[(rightBorder + 1)..];
                    if (!IsOnlyDigit(expression))
                    {
                        i = 0;
                    }
                }
            }

            return int.Parse(expression);
        }

        private static bool IsOnlyDigit(string expression)
        {
            bool isOnlyDigit = true;
            for (int i = 0; i < expression.Length; i++)
            {
                if (_operators.Contains(expression[i]) || char.IsWhiteSpace(expression[i]))
                {
                    isOnlyDigit = false;
                    break;
                }
            }

            return isOnlyDigit;
        }

        private static void CheckString(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException(nameof(expression), "Expression is a null");
            }

            int countDigits = 0;
            int countOperators = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (_operators.Contains(expression[i]) && i < 4)
                {
                    throw new ArgumentException("Expression does not contain two digits before first operator");
                }
                else if (!char.IsDigit(expression[i]) && !char.IsWhiteSpace(expression[i]) && !_operators.Contains(expression[i]))
                {
                    throw new ArgumentException("One of the symbols in expression is neither digit nor operator");
                }
                else if ((i + 1 < expression.Length && _operators.Contains(expression[i]) && !char.IsWhiteSpace(expression[i + 1])) ||
                    (i - 1 >= 0 && _operators.Contains(expression[i]) && !char.IsWhiteSpace(expression[i - 1])))
                {
                    throw new ArgumentException("Expression does not contain gaps between operators and other symbols");
                }

                if ((i + 1 < expression.Length && char.IsDigit(expression[i]) && char.IsWhiteSpace(expression[i + 1]))
                    || (i + 1 == expression.Length && char.IsDigit(expression[i])))
                {
                    countDigits++;
                }
                else if (_operators.Contains(expression[i]))
                {
                    countOperators++;
                }
            }

            if (countDigits - 1 != countOperators)
            {
                throw new ArgumentException("Quantity of digits and operators is not proportional");
            }
            else if (countDigits - 1 == countOperators && !_operators.Contains(expression[^1]))
            {
                throw new ArgumentException("Broken sequence of digits and operators");
            }
        }
    }
}
