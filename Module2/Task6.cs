using System;

namespace Module2
{
    public static class Task6
    {
        public static int[] FilterDigit(int[] arr, int digit)
        {
            int countResultArraySize = arr.Length;
            int lastFreeIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsContainsDigit(arr[i], digit))
                {
                    countResultArraySize--;
                }
                else
                {
                    Common.SwapElements<int>(ref arr[i], ref arr[lastFreeIndex]);
                    lastFreeIndex++;
                }
            }

            int[] resultArr = new int[countResultArraySize];
            Array.Copy(arr, resultArr, countResultArraySize);
            return resultArr;
        }

        internal static bool IsContainsDigit(int number, int digit)
        {
            bool isContains = false;
            number = Math.Abs(number);
            while (!isContains)
            {
                if (number % 10 == digit)
                {
                    isContains = true;
                }

                number /= 10;
                if (number == 0)
                {
                    break;
                }
            }

            return isContains;
        }
    }
}
