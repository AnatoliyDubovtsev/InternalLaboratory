using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Module2.MSTests
{
    [TestClass]
    public class InsertNumberTests
    {
        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 1, 0, 0, 9)]
        [DataRow(8, 1, 1, 1, 10)]
        [DataRow(8, 5, 0, 2, 13)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(8, 15, 4, 9, 248)]
        [DataRow(0, 1, 30, 30, 1073741824)]
        [DataRow(55, 3520, 6, 12, 4151)]
        [DataRow(1984, 1999, 0, 2, 1991)]
        public void InsertNumber_ReturnsResultNumber(int numberSource, int numberIn, int i, int j, int expectedResult)
            => Assert.AreEqual(expectedResult, Task1.InsertNumber(numberSource, numberIn, i, j));

        [DataTestMethod]
        [DataRow(5, 15, -1, 0)]
        [DataRow(5, 15, 0, -1)]
        [DataRow(5, 15, -1, -1)]
        [DataRow(5, 15, 5, 4)]
        [DataRow(5, 15, 1, 32)]
        [DataRow(5, 15, 32, 1)]
        public void InsertNumber_IncorrectInput_ThrowsArgumentException(int numberSource, int numberIn, int i, int j)
            => Assert.ThrowsException<ArgumentException>(() => Task1.InsertNumber(numberSource, numberIn, i, j));
    }
}
