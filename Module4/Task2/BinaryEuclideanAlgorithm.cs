using System;
using Common;

namespace Module4.Task2
{
    public class BinaryEuclideanAlgorithm : IGcdAlgorithm
    {
        public int FindGcd(params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Quantity of numbers must be 2 or more");
            }

            CollectionsCommonMethods.AbsNumbersInCollection(ref numbers);
            int result = 1;
            bool isOnlyOneNumberMoreThanZero = CollectionsCommonMethods.IsOnlyOneNumberMoreThanZero(numbers);
            while (!isOnlyOneNumberMoreThanZero)
            {
                bool isAllNumbersEven = true;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0 && numbers[i] != 0)
                    {
                        numbers[i] /= 2;
                    }
                    else if (numbers[i] % 2 != 0)
                    {
                        isAllNumbersEven = false;
                    }
                }

                if (isAllNumbersEven)
                {
                    result *= 2;
                }

                for (int i = 1; i < numbers.Length; i++)
                {
                    for (int j = 0; j < numbers.Length - i; j++)
                    {
                        if (numbers[j] % 2 != 0 && numbers[i] % 2 != 0 && numbers[j] > numbers[i])
                        {
                            numbers[j] = (numbers[j] - numbers[i]) / 2;
                        }
                        else if (numbers[j] % 2 != 0 && numbers[i] % 2 != 0)
                        {
                            numbers[i] = (numbers[i] - numbers[j]) / 2;
                        }
                    }
                }

                isOnlyOneNumberMoreThanZero = CollectionsCommonMethods.IsOnlyOneNumberMoreThanZero(numbers);
            }

            result *= CollectionsCommonMethods.FindNotZeroElement(numbers);
            return result;
        }
    }
}
