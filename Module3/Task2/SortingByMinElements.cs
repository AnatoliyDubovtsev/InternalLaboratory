using Common;

namespace Module3.Task2
{
    public class SortingByMinElements : ISortingStrategy
    {
        public int[][] SortMatrix(int[][] matrix, bool isAscendingSorting)
        {
            CommonMethods.IndexBorderIterationForArraySorting(out int index, out int border, out int iteration, matrix[0].Length, isAscendingSorting);
            int currentMin, nextMin;
            for (; index != border; index += iteration)
            {
                for (int j = index + iteration; j != border; j += iteration)
                {
                    currentMin = CommonMethods.FindMinElementInArray(matrix[index]);
                    nextMin = CommonMethods.FindMinElementInArray(matrix[j]);
                    if (currentMin > nextMin)
                    {
                        CommonMethods.SwapElements<int[]>(ref matrix[index], ref matrix[j]);
                    }
                }
            }

            return matrix;
        }
    }
}