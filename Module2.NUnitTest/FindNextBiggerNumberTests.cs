using NUnit.Framework;
using System;

namespace Module2.NUnitTests
{
    public class FindNextBiggerNumberTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(125432617, ExpectedResult = 125432671)]
        [TestCase(165743210, ExpectedResult = 167012345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_ReturnsResultNumber(int number)
            => Task5.FindNextBiggerNumber(number, out double elapsedMilliseconds);

        [TestCase(0)]
        [TestCase(-1)]
        public void FindNextBiggerNumber_ThrowsArgumentException(int number)
            => Assert.Throws<ArgumentException>(() => Task5.FindNextBiggerNumber(number, out double elapsedMilliseconds));
    }
}
