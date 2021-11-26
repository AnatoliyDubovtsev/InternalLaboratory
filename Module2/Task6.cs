using System;

namespace Module2
{
    public static class Task6
    {
        public static int[] FilterDigit(int[] arr, int digit)
        {
            int countResultArraySize = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!isContainsDigit(arr[i], digit))
                {
                    arr[i] = 0;
                    countResultArraySize--;
                }
            }

            int[] resultArr = new int[countResultArraySize];
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    resultArr[j++] = arr[i];
                }
            }

            return resultArr;
        }

        internal static bool isContainsDigit(int number, int digit)
        {
            bool isContains = false;
            number = Math.Abs(number);
            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    isContains = true;
                    break;
                }

                number /= 10;
            }

            return isContains;
        }
    }
}
