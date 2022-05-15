using Module9.Task2;
using NUnit.Framework;
using System;

namespace Module9Tests.Task2Tests
{
    public class SortTests
    {
        private static readonly int[,] _matrixForTest = new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 5, 6 } };
        
        [Test]
        public void Sort_CorrectInput_ReturnResultString()
        {
            var result = SortingMatrix.Sort(_matrixForTest, true);
            Assert.AreNotEqual("", result);
        }

        [Test]
        public void Sort_NullMatrixInput_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => SortingMatrix.Sort(null, false));
    }
}
