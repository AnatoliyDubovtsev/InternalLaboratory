using NUnit.Framework;
using System;

namespace Module2.NUnitTests
{
    [TestFixture]
    public class InsertNumberTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 1, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 1, 1, 1, ExpectedResult = 10)]
        [TestCase(8, 5, 0, 2, ExpectedResult = 13)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(8, 15, 4, 9, ExpectedResult = 248)]
        [TestCase(0, 1, 30, 30, ExpectedResult = 1073741824)]
        [TestCase(55, 3520, 6, 12, ExpectedResult = 4151)]
        [TestCase(1984, 1999, 0, 2, ExpectedResult = 1991)]
        public int InsertNumber_ReturnsResultNumber(int numberSource, int numberIn, int i, int j)
            => Task1.InsertNumber(numberSource, numberIn, i, j);

        [TestCase(5, 15, 1, 0)]
        [TestCase(5, 15, -1, 1)]
        [TestCase(5, 15, -1, -1)]
        [TestCase(5, 15, 32, 31)]
        [TestCase(5, 15, 31, 32)]
        public void InsertNumber_ThrowsArgumentException(int numberSource, int numberIn, int i, int j)
            => Assert.Throws<ArgumentException>(() => Task1.InsertNumber(numberSource, numberIn, i, j));
    }
}