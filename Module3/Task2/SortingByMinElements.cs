using Common;

namespace Module3.Task2
{
    public class SortingByMinElements : ISortingStrategy
    {
        public int[,] SortMatrix(int[,] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForMatrixSorting(out int row, out int border, out int iteration, matrix.GetLength(matrix.Rank - 1), isAscendingSorting);
            int currentMin, nextMin;
            for (; row != border; row += iteration)
            {
                for (int nextRow = row + iteration; nextRow != border; nextRow += iteration)
                {
                    currentMin = CommonMethods.FindMinElementInMatrixRow(matrix, row);
                    nextMin = CommonMethods.FindMinElementInMatrixRow(matrix, nextRow);
                    if (currentMin > nextMin)
                    {
                        CommonMethods.SwapElementsInMatrixRows(matrix, row, nextRow);
                    }
                }
            }

            return matrix;
        }
    }
}