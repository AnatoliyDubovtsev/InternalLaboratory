using System;
using System.Text;
using Common;

namespace Module4
{
    public static class Task1
    {
        public static string ConvertDoubleToIEEE754(this double number)
        {
            bool isPositive = number >= 0;
            number = Math.Abs(number);
            string numberString = number.ToString();            
            string[] wholeAndFloatingPointParts = numberString.Split(',');
            bool isContainsComma = wholeAndFloatingPointParts.Length == 2;
            /*int decExp = 0;
            if (isContainsComma && wholeAndFloatingPointParts[1].Contains('E'))
            {
                int index = wholeAndFloatingPointParts[1].IndexOf('E');
                string exp = wholeAndFloatingPointParts[1].Substring(index + 1);
                decExp = int.Parse(exp);
                wholeAndFloatingPointParts[1] = wholeAndFloatingPointParts[1].Remove(index);
            }*/

            int count = 1;
            
            long.TryParse(wholeAndFloatingPointParts[0], out long wholePartOfNumber);
            char[] wholePartInBinaryFormat = OperationsWithElements.WholeDecNumberToBin(wholePartOfNumber).ToCharArray();
            Array.Reverse(wholePartInBinaryFormat);
            count += wholePartInBinaryFormat.Length;

            int exponent = wholePartInBinaryFormat.Length - 1;
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
                resultStringBuilder.Append(item);
            }

            for(int i = 1; i < wholePartInBinaryFormat.Length; i++)
            {
                resultStringBuilder.Append(wholePartInBinaryFormat[i]);
            }

            if (isContainsComma)
            {
                foreach (var item in floatingPointPartInBinaryFormat)
                {
                    resultStringBuilder.Append(item);
                }
            }

            for (int i = 0; i < residualZeros; i++)
            {
                resultStringBuilder.Append(0);
            }

            return resultStringBuilder.ToString();
        }
    }
}
