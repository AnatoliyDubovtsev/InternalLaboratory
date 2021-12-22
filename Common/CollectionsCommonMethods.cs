using System;

namespace Common
{
    public static class CollectionsCommonMethods
    {
        public static void ShowCollectionItems<T>(T[] collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            int i = 0;
            foreach (var item in collection)
            {
                Console.WriteLine($"{i++} {item}");
            }
        }

        public static int FindIndexOfElement(string numberString, char element)
        {
            for(int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int FindMinElement(int[] numbers, out int indexOfMin)
        {
            int min = numbers[0];
            indexOfMin = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                    indexOfMin = i;
                }
            }

            return min;
        }

        public static bool IsOnlyOneNumberMoreThanZero(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    count++;
                }

                if (count > 1)
                {
                    break;
                }
            }

            return count == 1;
        }

        public static int FindNotZeroElement(int[] numbers)
        {
            int number = -1;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    number = numbers[i];
                    break;
                }
            }

            return number;
        }
    }
}
