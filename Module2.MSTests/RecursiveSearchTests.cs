using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Module2.MSTests
{
    [TestClass]
    public class RecursiveSearchTests
    {
        [DataTestMethod]
        [DataRow(new int[5] { 5, 3, 4, 6, 2 }, 6)]
        [DataRow(new int[10] { 1, 5, 2, 3, 4, 7, 8, 1, 5, 9 }, 9)]
        [DataRow(new int[10] { 10, 5, 10, 4, 3, 7, 8, 1, 5, 9 }, 10)]
        [DataRow(new int[10] { 1, 5, 5, 4, 3, 7, 8, 1, 5, 10 }, 10)]
        [DataRow(new int[1] { 0 }, 0)]
        [DataRow(new int[3] { 1, 1, 1 }, 1)]
        public void RecursiveSearch_ReturnsMaxNumber(int[] arr, int expectedResult)
            => Assert.AreEqual(expectedResult, Task2.RecursiveSearch(arr));

        [DataTestMethod]
        [DataRow(new int[] { })]
        public void RecursiveSearch_ThrowsArgumentExceptionIfArrLengthIsZero(int[] arr)
            => Assert.ThrowsException<ArgumentException>(() => Task2.RecursiveSearch(arr));
    }
}
