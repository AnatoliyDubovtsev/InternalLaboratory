using System;
using System.Text;
using Common;

namespace Module4
{
    public static class Task1
    {
        public static string ConvertDoubleToIEEE754(this double number)
        {
            bool isPositive = number > 0;
            number = Math.Abs(number);
            string numberString = number.ToString();
            //int index = numberString.IndexOf('E');
            //numberString = numberString.Remove(index);
            string[] wholeAndFloatingPointParts = numberString.Split(',');
            bool isContainsComma = wholeAndFloatingPointParts.Length == 2;
            int count = 1;
            
            long wholePartOfNumber = Convert.ToInt64(wholeAndFloatingPointParts[0]);
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
                double floatingPointPart = Convert.ToDouble("0," + wholeAndFloatingPointParts[1]);
                floatingPointPartInBinaryFormat = OperationsWithElements.FloatingPointDecNumberToBin(floatingPointPart, 64 - count).ToCharArray();
            }

            int residualZeros = 64 - wholePartInBinaryFormat.Length - floatingPointPartInBinaryFormat.Length - exponentInBinaryFormat.Length;
            StringBuilder resultStringBuilder = new StringBuilder();
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
