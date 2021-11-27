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

        public static void IndexBorderIterationForMatrixSorting(out int row, out int border, out int iteration, int matrixRowLength, bool isAscending)
        {
            row = isAscending ? 0 : matrixRowLength - 1;
            border = isAscending ? matrixRowLength : -1;
            iteration = isAscending ? 1 : -1;
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
            for (int row = 0; row <= matrix.Rank; row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
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
    }
}