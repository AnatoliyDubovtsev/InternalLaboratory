using Common;

namespace Module3.Task2
{
    public class SortingBySum : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            int currentSum, nextSum;
            int border = matrix.GetLength(0);
            for (int row = 1; row < border; row++)
            {
                for (int nextRow = 0; nextRow < border - row; nextRow++)
                {
                    currentSum = MatrixCommonMethods.CountSumOfElementsInMatrixRow(matrix, nextRow);
                    nextSum = MatrixCommonMethods.CountSumOfElementsInMatrixRow(matrix, nextRow + 1);
                    if (currentSum > nextSum && isAscendingSorting)
                    {
                        MatrixCommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                    else if (currentSum < nextSum && !isAscendingSorting)
                    {
                        MatrixCommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                }
            }

            return matrix;
        }
    }
}