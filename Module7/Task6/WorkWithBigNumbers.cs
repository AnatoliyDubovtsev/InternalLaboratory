using System;
using System.Numerics;

namespace Module7.Task6
{
    public static class WorkWithBigNumbers
    {
        public static string Sum(string left, string right)
        {
            if (string.IsNullOrEmpty(left))
            {
                throw new ArgumentNullException(nameof(left), "Left string is null or empty");
            }
            else if (string.IsNullOrEmpty(right))
            {
                throw new ArgumentNullException(nameof(right), "Right string is null or empty");
            }

            if (left.StartsWith(' ') || left.EndsWith(' '))
            {
                left = left.Trim();
            }
            
            if (right.StartsWith(' ') || right.EndsWith(' '))
            {
                right = right.Trim();
            }

            string result;
            try
            {
                BigInteger leftNumber = BigInteger.Parse(left);
                BigInteger rightNumber = BigInteger.Parse(right);
                result = (leftNumber + rightNumber).ToString();
            }
            catch(FormatException ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
