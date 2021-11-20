using System;

namespace Module2
{
    public static class Task2
    {
        public static int RecursiveSearch(int[] arr)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(arr));
            }

            int id = 0;
            int current = arr[id++];
            return IsMax(arr, id, current);
        }

        private static int IsMax(int[] arr, int id, int current)
        {
            if (id == arr.Length)
            {
                return current;
            }
            else if (current >= arr[id])
            {
                id++;
                return IsMax(arr, id, current);
            }
            else
            {
                current = arr[id];
                id++;
                return IsMax(arr, id, current);
            }
        }
    }
}
