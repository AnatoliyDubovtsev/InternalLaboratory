using Common;

namespace Module3.Task2
{
    public class SortingBySum : ISortingStrategy
    {
        public int[][] SortMatrix(int[][] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForArraySorting(out int index, out int border, out int iteration, matrix[0].Length, isAscendingSorting);
            int currentSum, nextSum;
            for (; index != border; index += iteration)
            {
                for (int j = index + iteration; j != border; j += iteration)
                {
                    currentSum = CommonMethods.CountSumOfElementsInArray(matrix[index]);
                    nextSum = CommonMethods.CountSumOfElementsInArray(matrix[j]);
                    if (currentSum > nextSum)
                    {
                        CommonMethods.SwapElements<int[]>(ref matrix[index], ref matrix[j]);
                    }
                }
            }

            return matrix;
        }
    }
}
