using NUnit.Framework;

namespace Module3.Tests
{
    [TestFixture]
    public class MatrixSortMethodsTests
    {
        private const int quantity = 5;
        private int[][,] inputMatrixes;
        private int[][,] expectedMatrixes_SortingBySum_Ascending;
        private int[][,] expectedMatrixes_SortingBySum_Discending;
        private int[][,] expectedMatrixes_SortingByMin_Ascending;
        private int[][,] expectedMatrixes_SortingByMin_Discending;
        private int[][,] expectedMatrixes_SortingByMax_Ascending;
        private int[][,] expectedMatrixes_SortingByMax_Discending;

        [SetUp]
        public void SetUp()
        {
            inputMatrixes = new int[][,]
            {
                new int[,] { },
                new int[,] { { 1 } },
                new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 5, 6 } },
                new int[,] { { 1, 5, 7, 9 }, { 2, 0, 8, 5 }, { 3, 2, 5, 2 }, { 5, 4, 7, 10 } },
                new int[,] { { 10, 7, 5, 3 }, { 15, 5, 2, 8 }, { 12, 7, 9, 0 }, { 8, 7, 1, 5 } }
            };

            expectedMatrixes_SortingBySum_Ascending = new int[][,]
            {
                new int[,] { },
                new int[,] { { 1 } },
                new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 5, 6 } },
                new int[,] { { 3, 2, 5, 2 }, { 2, 0, 8, 5 }, { 1, 5, 7, 9 }, { 5, 4, 7, 10 } },
                new int[,] { { 8, 7, 1, 5 }, { 10, 7, 5, 3 }, { 12, 7, 9, 0 }, { 15, 5, 2, 8 } }
            };

            expectedMatrixes_SortingByMin_Ascending = new int[][,]
            {
                new int[,] { },
                new int[,] { { 1 } },
                new int[,] { { 4, 0, 8 }, { 1, 2, 3 }, { 6, 5, 6 } },
                new int[,] { { 2, 0, 8, 5 }, { 1, 5, 7, 9 }, { 3, 2, 5, 2 }, { 5, 4, 7, 10} },
                new int[,] { { 12, 7, 9, 0 }, { 8, 7, 1, 5 }, { 15, 5, 2, 8 }, { 10, 7, 5, 3 } }
            };

            expectedMatrixes_SortingByMax_Ascending = new int[][,]
            {
                new int[,] { },
                new int[,] { { 1 } },
                new int[,] { { 1, 2, 3 }, { 6, 5, 6 }, { 4, 0, 8 } },
                new int[,] { { 3, 2, 5, 2 }, { 2, 0, 8, 5 }, { 1, 5, 7, 9 }, { 5, 4, 7, 10 } },
                new int[,] { { 8, 7, 1, 5 }, { 10, 7, 5, 3 }, { 12, 7, 9, 0 }, { 15, 5, 2, 8 } }
            };

            expectedMatrixes_SortingBySum_Discending = ReverseMatrix(expectedMatrixes_SortingBySum_Ascending);
            expectedMatrixes_SortingByMin_Discending = ReverseMatrix(expectedMatrixes_SortingByMin_Ascending);
            expectedMatrixes_SortingByMax_Discending = ReverseMatrix(expectedMatrixes_SortingByMax_Ascending);
        }
        
        [Test]
        [TestCase("bySum", 0, true)]
        [TestCase("bySum", 0, false)]
        [TestCase("byMin", 0, true)]
        [TestCase("byMin", 0, false)]
        [TestCase("byMax", 0, true)]
        [TestCase("byMax", 0, false)]
        public void SortMatrix_ReturnsResultMatrix(string typeOfSortingMethod, int row, bool isAscending)
        {
            //Arrange
            var method = GetSortingMethod(typeOfSortingMethod);
            while (row < quantity)
            {
                var expected = GetMatrixForTest(typeOfSortingMethod, row, isAscending);

                //Act
                var actual = method.SortMatrix(inputMatrixes[row++], isAscending);

                //Assert
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        private int[,] GetMatrixForTest(string typeOfSortingMethod, int row, bool isAscending)
            => typeOfSortingMethod switch
            {
                "bySum" when isAscending => expectedMatrixes_SortingBySum_Ascending[row],
                "bySum" when !isAscending => expectedMatrixes_SortingBySum_Discending[row],
                "byMin" when isAscending => expectedMatrixes_SortingByMin_Ascending[row],
                "byMin" when !isAscending => expectedMatrixes_SortingByMin_Discending[row],
                "byMax" when isAscending => expectedMatrixes_SortingByMax_Ascending[row],
                "byMax" when !isAscending => expectedMatrixes_SortingByMax_Discending[row],
                _ => new int[,] {}
            };

        private static Task2.ISortingStrategy GetSortingMethod(string typeOfSortingMethod)
            => typeOfSortingMethod switch
            {
                "bySum" => new Task2.SortingBySum(),
                "byMin" => new Task2.SortingByMinElements(),
                "byMax" => new Task2.SortingByMaxElements(),
                _ => null
            };

        private int[][,] ReverseMatrix(int[][,] matrix)
        {
            int[][,] result = new int[matrix.Length][,];
            for(int outerRow = 0; outerRow < matrix.Length; outerRow++)
            {
                result[outerRow] = new int[matrix[outerRow].GetLength(0), matrix[outerRow].GetLength(0)];
                for (int row = 0, sourceRow = matrix[outerRow].GetLength(0) - 1; row < matrix[outerRow].GetLength(0); row++, sourceRow--)
                {
                    for (int col = 0; col < matrix[outerRow].GetLength(0); col++)
                    {
                        result[outerRow][row, col] = matrix[outerRow][sourceRow, col];
                    }
                }
            }

            return result;
        }
    }
}