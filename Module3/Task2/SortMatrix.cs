#pragma warning disable S2368
using Common;
using System;

namespace Module3.Task2
{
    public class SortMatrix
    {
        private readonly ISortingStrategy _sortingStrategy;

        public SortMatrix(ISortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy;
        }

        public void Sorting(int[,] matrix, bool isAscendingSorting)
        {
            Console.WriteLine("Matrix before sorting");
            MatrixCommonMethods.ShowMatrix<int>(matrix);
            _sortingStrategy.SortMatrix(matrix, isAscendingSorting);
            Console.WriteLine("Matrix after sorting");
            MatrixCommonMethods.ShowMatrix<int>(matrix);
        }
    }
}