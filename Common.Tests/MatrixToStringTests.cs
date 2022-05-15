using NUnit.Framework;
using System;

namespace Common.Tests
{
    public class MatrixToStringTests
    {
        private static readonly int[,] _matrixForTest = new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 5, 6 } };

        [Test]
        public void MatrixToString_CorrectInput_ReturnsResultString()
        {
            //arrange
            var expected = $"1 2 3{Environment.NewLine}4 0 8{Environment.NewLine}6 5 6";

            //act
            var result = MatrixCommonMethods.MatrixToString<int>(_matrixForTest);

            //assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MatrixToString_NullInput_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => MatrixCommonMethods.MatrixToString<int>(null));
    }
}
