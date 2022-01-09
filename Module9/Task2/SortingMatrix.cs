#pragma warning disable S2368
using Module3.Task2;
using System;
using System.Text;

namespace Module9.Task2
{
    public delegate int[,] SortingMatrixHandler(int[,] matrix, bool isAscendingSorting);

    public static class SortingMatrix
    {
        private static readonly ISortingStrategy[] sortingStrategies = { new SortingByMinElements(), new SortingByMaxElements(), new SortingBySum() };

        public static string Sort(int[,] matrix, bool isAscending)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix is a null");
            }

            SortingMatrixHandler sortingMatrixHandler = null;
            StringBuilder result = new();
            int[,] resultMatrix;
            for (int i = 0; i < sortingStrategies.Length; i++)
            {
                sortingMatrixHandler += sortingStrategies[i].SortMatrix;
                resultMatrix = sortingMatrixHandler.Invoke(matrix, isAscending);
                result.Append($"Sorting strategy: {sortingMatrixHandler.Method.DeclaringType.Name}{Environment.NewLine}" +
                    $"Is ascending: {isAscending}{Environment.NewLine}" +
                    $"Result matrix{Environment.NewLine}" +
                    $"{Common.MatrixCommonMethods.MatrixToString<int>(resultMatrix)}{Environment.NewLine}{Environment.NewLine}");
                sortingMatrixHandler -= sortingStrategies[i].SortMatrix;
            }

            return result.ToString();
        }
    }
}
