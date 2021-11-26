using Common;

namespace Module3.Task2
{
    public class SortingByMaxElements : ISortingStrategy
    {
        public int[][] SortMatrix(int[][] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForArraySorting(out int index, out int border, out int iteration, matrix[0].Length, isAscendingSorting);
            int currentMax, nextMax;
            for (; index != border; index += iteration)
            {
                for (int j = index + iteration; j != border; j += iteration)
                {
                    currentMax = CommonMethods.FindMaxElementInArray(matrix[index]);
                    nextMax = CommonMethods.FindMaxElementInArray(matrix[j]);
                    if (currentMax > nextMax)
                    {
                        CommonMethods.SwapElements<int[]>(ref matrix[index], ref matrix[j]);
                    }
                }
            }

            return matrix;
        }
    }
}
