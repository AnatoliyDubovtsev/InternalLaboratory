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

            BigInteger result;
            try
            {
                BigInteger leftNumber = BigInteger.Parse(left);
                BigInteger rightNumber = BigInteger.Parse(right);
                result = leftNumber + rightNumber;
            }
            catch(FormatException ex)
            {
                return ex.Message;
            }

            return result.ToString();
        }
    }
}
