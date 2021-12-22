using Common;

namespace Module3.Task2
{
    public class SortingByMaxElements : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            int currentMax, nextMax;
            int border = matrix.GetLength(0);
            for (int row = 1; row < border; row++)
            {
                for (int nextRow = 0; nextRow < border - row; nextRow++)
                {
                    currentMax = MatrixCommonMethods.FindMaxElementInMatrixRow(matrix, nextRow);
                    nextMax = MatrixCommonMethods.FindMaxElementInMatrixRow(matrix, nextRow + 1);
                    if (currentMax > nextMax && isAscendingSorting)
                    {
                        MatrixCommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                    else if (currentMax < nextMax && !isAscendingSorting)
                    {
                        MatrixCommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                }
            }

            return matrix;
        }
    }
}