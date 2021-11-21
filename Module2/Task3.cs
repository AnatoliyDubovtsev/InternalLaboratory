﻿namespace Module2
{
    public static class Task3
    {
        public static int IndexOfElementWithEqualSumOnBothSides(double[] arr)
        {
            double leftSum = 0;
            double rightSum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                rightSum += arr[i];
            }

            double percent = 0.0001;
            int index = 0;
            while (index < arr.Length)
            {
                double max = leftSum > rightSum ? leftSum : rightSum;
                double min = leftSum > rightSum ? rightSum : leftSum;
                if (max - min <= max * percent)
                {
                    return index;
                }

                leftSum += arr[index++];
                if (index == arr.Length)
                {
                    break;
                }

                rightSum -= arr[index];
            }

            return -1;
        }
    }
}
