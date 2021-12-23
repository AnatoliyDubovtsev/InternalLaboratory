using System;
using System.Diagnostics;
using Common;

namespace Module4.Task2
{
    public class EuclideanAlgorithm : IGcdAlgorithm
    {
        public int FindGcd(out double elapsedMilliseconds, params int[] numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Quantity of numbers must be 2 or more");
            }

            CollectionsCommonMethods.AbsNumbersInCollection(ref numbers);
            bool isOnlyOneNumberMoreThanZero = CollectionsCommonMethods.IsOnlyOneNumberMoreThanZero(numbers);
            while (!isOnlyOneNumberMoreThanZero)
            {
                int min = CollectionsCommonMethods.FindMinElementMoreThanZero(numbers, out int indexOfMin);
                bool isMoreThanMin;
                do
                {
                    isMoreThanMin = false;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (indexOfMin != i && numbers[i] != 0 && numbers[i] >= min)
                        {
                            numbers[i] -= min;
                            isMoreThanMin = true;
                        }
                    }
                } while (isMoreThanMin);

                isOnlyOneNumberMoreThanZero = CollectionsCommonMethods.IsOnlyOneNumberMoreThanZero(numbers);
            }

            int result = CollectionsCommonMethods.FindNotZeroElement(numbers);
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            elapsedMilliseconds = timeSpan.TotalMilliseconds;
            return result;
        }
    }
}
