using System;
using System.Text;
using Common;

namespace Module4
{
    public static class Task1
    {
        public static string ConvertDoubleToIEEE754(this double number)
        {
            const int bits = 64;
            const int exponentOffset = 1023;
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
            string[] wholeAndFloatingPointParts = null;
            double wholePartOfNumber = 0;
            double floatingPointPart = 0;
            bool hasWholePartOfNumber = true;
            if (numberString.Contains("E-"))
            {
                floatingPointPart = number;
                hasWholePartOfNumber = false;
            }
            else if (numberString.Contains('E'))
            {
                wholePartOfNumber = number;
            }
            else
            {
                wholeAndFloatingPointParts = numberString.Split(',');
            }

            bool isArrayOfNumbersPartsNull = wholeAndFloatingPointParts == null;
            if (!isArrayOfNumbersPartsNull)
            {
                double.TryParse(wholeAndFloatingPointParts[0], out wholePartOfNumber);
            }

            char[] wholePartInBinaryFormat = new char[] { };
            if (hasWholePartOfNumber)
            {
                wholePartInBinaryFormat = OperationsWithElements.WholeDecNumberToBin(wholePartOfNumber).ToCharArray();
                Array.Reverse(wholePartInBinaryFormat);
            }
            
            int length = wholePartInBinaryFormat.Length;
            int exponent = length == 0 ? -exponentOffset : length - 1;
            char[] exponentInBinaryFormat = OperationsWithElements.WholeDecNumberToBin(exponent + exponentOffset).ToCharArray();
            Array.Reverse(exponentInBinaryFormat);
            char[] floatingPointPartInBinaryFormat;

            if (!isArrayOfNumbersPartsNull && wholeAndFloatingPointParts.Length == 2)
            {
                double.TryParse("0," + wholeAndFloatingPointParts[1], out floatingPointPart);
            }

            floatingPointPartInBinaryFormat = OperationsWithElements.FloatingPointDecNumberToBinWithLast64Bits(floatingPointPart).ToCharArray();
            int residualZeros = bits - wholePartInBinaryFormat.Length - floatingPointPartInBinaryFormat.Length - exponentInBinaryFormat.Length;
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
                resultStringBuilder.Append(item);
            }

            for (int i = 1; i < wholePartInBinaryFormat.Length && resultStringBuilder.Length < bits; i++)
            {
                resultStringBuilder.Append(wholePartInBinaryFormat[i]);
            }

            for (int i = 0; i < floatingPointPartInBinaryFormat.Length && resultStringBuilder.Length < bits; i++)
            {
                resultStringBuilder.Append(floatingPointPartInBinaryFormat[i]);
            }

            for (int i = 0; i < residualZeros && resultStringBuilder.Length < bits; i++)
            {
                resultStringBuilder.Append(0);
            }

            return resultStringBuilder.ToString();
        }
    }
}
