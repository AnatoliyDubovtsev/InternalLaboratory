using Common;

namespace Module3.Task2
{
    public class SortingByMaxElements : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForMatrixSorting(out int row, out int border, out int iteration, matrix.GetLength(matrix.Rank - 1), isAscendingSorting);
            int currentMax, nextMax;
            for (; row != border; row += iteration)
            {
                for (int nextRow = row + iteration; nextRow != border; nextRow += iteration)
                {
                    currentMax = CommonMethods.FindMaxElementInMatrixRow(matrix, row);
                    nextMax = CommonMethods.FindMaxElementInMatrixRow(matrix, nextRow);
                    if (currentMax > nextMax)
                    {
                        CommonMethods.SwapElementsInMatrixRows(matrix, row, nextRow);
                    }
                }
            }

            return matrix;
        }
    }
}