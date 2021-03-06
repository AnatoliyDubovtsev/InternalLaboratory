using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Common.Tests
{
    public class ShowMatrixTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 5)]
        [TestCase(1, 0)]
        public void ShowMatrix_ReturnsResult(int numberOfRows, int numberOfColumns)
        {
            //arrange
            using var writer = new StringWriter();
            Console.SetOut(writer);
            var matrixForTests = CreateMatrixForTestsAndExpectedResultString(numberOfRows, numberOfColumns, out string expectedResult);

            //act
            MatrixCommonMethods.ShowMatrix<int>(matrixForTests);
            var actual = writer.ToString();

            //assert
            Assert.AreEqual(expectedResult, actual);
        }

        [TestCase(null)]
        public void ShowMatrix_ThrowsArgumentNullException(int[,] matrix)
            => Assert.Throws<ArgumentNullException>(() => MatrixCommonMethods.ShowMatrix<int>(matrix));

        private static int[,] CreateMatrixForTestsAndExpectedResultString(int numberOfRows, int numberOfColumns, out string expectedResult)
        {
            var matrixForTests = new int[numberOfRows, numberOfColumns];
            var stringBuilder = new StringBuilder();
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    matrixForTests[row, col] = col;
                    stringBuilder.Append(col + " ");
                }

                stringBuilder.Append(Environment.NewLine);
            }

            expectedResult = stringBuilder.ToString();
            return matrixForTests;
        }
    }
}
