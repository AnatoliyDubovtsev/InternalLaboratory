using System;
using System.Text;
using Common;

namespace Module4
{
    public static class Task1
    {
        public static string ConvertDoubleToIEEE754(this double number)
        {
            if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }
            else if (double.IsPositiveInfinity(number))
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }
            else if (double.IsNegativeInfinity(number))
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            bool isPositive = number >= 0;
            number = Math.Abs(number);
            string numberString = number.ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(number);
            string[] wholeAndFloatingPointParts;
            if (numberString.Contains("E-"))
            {
                wholeAndFloatingPointParts = new string[] { "0", numberString };
            }
            else if (numberString.Contains('E'))
            {
                wholeAndFloatingPointParts = new string[] { numberString };
            }
            else
            {
                wholeAndFloatingPointParts = numberString.Split(',');
            }

            bool isContainsComma = wholeAndFloatingPointParts.Length == 2;
            int count = 1;
            double.TryParse(wholeAndFloatingPointParts[0], out double wholePartOfNumber);
            char[] wholePartInBinaryFormat = OperationsWithElements.WholeDecNumberToBin(wholePartOfNumber).ToCharArray();
            Array.Reverse(wholePartInBinaryFormat);
            count += wholePartInBinaryFormat.Length;
            int length = wholePartInBinaryFormat.Length;
            int exponent = length == 0 ? -1023 : length - 1;
            char[] exponentInBinaryFormat = OperationsWithElements.WholeDecNumberToBin(exponent + 1023).ToCharArray();
            Array.Reverse(exponentInBinaryFormat);
            count += exponentInBinaryFormat.Length;
            char[] floatingPointPartInBinaryFormat = new char[] { };
            if (isContainsComma)
            {
                double.TryParse("0," + wholeAndFloatingPointParts[1], out double floatingPointPart);
                floatingPointPartInBinaryFormat = OperationsWithElements.FloatingPointDecNumberToBin(floatingPointPart, 64 - count).ToCharArray();
            }

            int residualZeros = 64 - wholePartInBinaryFormat.Length - floatingPointPartInBinaryFormat.Length - exponentInBinaryFormat.Length;
            StringBuilder resultStringBuilder = new();
            if (isPositive)
            {
                resultStringBuilder.Append(0);
            }
            else
            {
                resultStringBuilder.Append(1);
            }

            foreach(var item in exponentInBinaryFormat)
            {
                if (resultStringBuilder.Length == 64)
                {
                    break;
                }
                resultStringBuilder.Append(item);
            }

            for(int i = 1; i < wholePartInBinaryFormat.Length && resultStringBuilder.Length < 64; i++)
            {
                resultStringBuilder.Append(wholePartInBinaryFormat[i]);
            }

            if (isContainsComma)
            {
                for(int i = 0; i < floatingPointPartInBinaryFormat.Length && resultStringBuilder.Length < 64; i++)
                {
                    resultStringBuilder.Append(floatingPointPartInBinaryFormat[i]);
                }
            }

            for (int i = 0; i < residualZeros && resultStringBuilder.Length < 64; i++)
            {
                resultStringBuilder.Append(0);
            }

            return resultStringBuilder.ToString();
        }
    }
}
