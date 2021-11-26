using System;

namespace Module2
{
    public static class Task1
    {
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("'i' cannot be more than 'j'", nameof(i));
            }
            else if (i < 0)
            {
                throw new ArgumentException("'i' cannot be less than 0", nameof(i));
            }
            else if (j > 31)
            {
                throw new ArgumentException("'j' cannot be more than 31", nameof(j));
            }

            int[] numberSourceArr = DecToBin(numberSource);
            int[] numberInArr = DecToBin(numberIn);
            int degree = numberSourceArr.Length;
            if (j == i && j > degree)
            {
                degree = j + 1;
            }
            else if (j - degree > 0)
            {
                degree += j - i + 1;
            }

            int[] resultNumberArr = new int[degree];
            for (int k = 0, arrI = 0; k < degree; k++)
            {
                if (k >= i && k <= j)
                {
                    resultNumberArr[k] = arrI >= numberInArr.Length ? 0 : numberInArr[arrI++];
                }
                else
                {
                    resultNumberArr[k] = k >= numberSourceArr.Length ? 0 : numberSourceArr[k];
                }
            }

            int resultNumber = 0;
            for (int k = degree - 1; k >= 0; k--)
            {
                resultNumber += (int)(Math.Pow(2, k) * resultNumberArr[k]);
            }

            return resultNumber;
        }

        private static int[] DecToBin(int number)
        {
            int degree = DegreeOfTwo(number);
            int[] resultArr = new int[degree];
            int counter = 0;
            while (number >= 1)
            {
                if (number == 1)
                {
                    resultArr[counter] = 1;
                    break;
                }

                resultArr[counter++] = number % 2;
                number /= 2;
            }

            return resultArr;
        }

        private static int DegreeOfTwo(int number)
        {
            int degree = 0;
            while (number > 0)
            {
                if (number == 1)
                {
                    degree++;
                    break;
                }

                number /= 2;
                degree++;
            }

            return degree;
        }
    }
}
