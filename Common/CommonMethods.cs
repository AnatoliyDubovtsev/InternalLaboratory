#pragma warning disable S2368
using System;

namespace Common
{
    public static class CommonMethods
    {
        public static void SwapElements<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        public static int CountSumOfElementsInMatrixRow(int[,] matrix, int row)
        {
            int sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[row, col];
            }

            return sum;
        }

        public static int FindMinElementInMatrixRow(int[,] matrix, int row)
        {
            int min = int.MaxValue;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (min > matrix[row, col])
                {
                    min = matrix[row, col];
                }
            }

            return min;
        }

        public static int FindMaxElementInMatrixRow(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (max < matrix[row, col])
                {
                    max = matrix[row, col];
                }
            }

            return max;
        }

        public static void ShowMatrix<T>(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix is a null.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void SwapElementsInMatrixRows<T>(T[,] matrix, int upperRow, int lowerRow)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                SwapElements<T>(ref matrix[upperRow, col], ref matrix[lowerRow, col]);
            }
        }

        public static void ShowCollectionItems<T>(T[] collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            int i = 0;
            foreach(var item in collection)
            {
                Console.WriteLine($"{i++} {item}");
            }
        }
    }
}