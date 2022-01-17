#pragma warning disable S2368
using System;
using System.Text;

namespace Common
{
    public static class MatrixCommonMethods
    {
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

        public static string MatrixToString<T>(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix is a null.");
            }

            StringBuilder stringBuilder = new();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    stringBuilder.Append(matrix[row, col]);
                    if (col != matrix.GetLength(1) - 1)
                    {
                        stringBuilder.Append(' ');
                    }
                }

                if (row != matrix.GetLength(0) - 1)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            }

            return stringBuilder.ToString();
        }

        public static void SwapElementsInMatrixRows<T>(T[,] matrix, int upperRow, int lowerRow)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                OperationsWithElements.SwapElements<T>(ref matrix[upperRow, col], ref matrix[lowerRow, col]);
            }
        }
    }
}