using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.Tests
{
    public class SortMatrixTests
    {
        public int[][] SortMatrixBySum_Ascending_ReturnsResultMatrix(int[][] matrix, bool isAscending)
        {
            var method = new Task2.SortingBySum();
            return method.SortMatrix(matrix, isAscending);
        }
    }
}
