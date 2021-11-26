using System;
using System.Diagnostics;

namespace Module2
{
    public static class Task5
    {
        public static int FindNextBiggerNumber(int number, out double elapsedMilliseconds)
        {
            if (number < 1)
            {
                throw new ArgumentException("Number cannot be less than 1", nameof(number));
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int quantity = QuantityOfDigits(number);
            int[] digits = new int[quantity];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            bool isFoundBiggerNumber = false;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                {
                    Common.SwapElements<int>(ref digits[i], ref digits[i + 1]);
                    SortArrayStartingFromFirstElementToIndex(digits, i + 1);
                    isFoundBiggerNumber = true;
                    break;
                }
            }

            if (!isFoundBiggerNumber)
            {
                elapsedMilliseconds = Common.ElapsedMilliseconds(stopwatch);
                return -1;
            }

            int resultNumber = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                resultNumber += digits[i];
                if (i != 0)
                {
                    resultNumber *= 10;
                }
            }

            elapsedMilliseconds = Common.ElapsedMilliseconds(stopwatch);
            return resultNumber;
        }

        internal static int QuantityOfDigits(int number)
        {
            int quantity = 0;
            while (number > 0)
            {
                number /= 10;
                quantity++;
            }

            return quantity;
        }

        internal static void SortArrayStartingFromFirstElementToIndex(int[] arr, int index)
        {
            for (int i = 0; i < index - 1; i++)
            {
                for (int j = i + 1; j < index; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        Common.SwapElements<int>(ref arr[i], ref arr[j]);
                    }
                }
            }
        }
    }
}
