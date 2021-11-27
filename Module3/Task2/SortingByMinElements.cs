using Common;

namespace Module3.Task2
{
    public class SortingByMinElements : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            int currentMin, nextMin;
            int border = matrix.GetLength(matrix.Rank - 1);
            for (int row = 1; row < border; row++)
            {
                for (int nextRow = 0; nextRow < border - row; nextRow++)
                {
                    currentMin = CommonMethods.FindMinElementInMatrixRow(matrix, nextRow);
                    nextMin = CommonMethods.FindMinElementInMatrixRow(matrix, nextRow + 1);
                    if (currentMin > nextMin && isAscendingSorting)
                    {
                        CommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                    else if (currentMin < nextMin && !isAscendingSorting)
                    {
                        CommonMethods.SwapElementsInMatrixRows<int>(matrix, nextRow, nextRow + 1);
                    }
                }
            }

            return matrix;
        }
    }
}