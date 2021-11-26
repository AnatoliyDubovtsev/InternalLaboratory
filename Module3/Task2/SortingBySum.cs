using Common;

namespace Module3.Task2
{
    public class SortingBySum : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForMatrixSorting(out int row, out int border, out int iteration, matrix.GetLength(matrix.Rank - 1), isAscendingSorting);
            int currentSum, nextSum;
            for (; row != border; row += iteration)
            {
                for (int nextRow = row + iteration; nextRow != border; nextRow += iteration)
                {
                    currentSum = CommonMethods.CountSumOfElementsInMatrixRow(matrix, row);
                    nextSum = CommonMethods.CountSumOfElementsInMatrixRow(matrix, nextRow);
                    if (currentSum > nextSum)
                    {
                        CommonMethods.SwapElementsInMatrixRows(matrix, row, nextRow);
                    }
                }
            }

            return matrix;
        }
    }
}