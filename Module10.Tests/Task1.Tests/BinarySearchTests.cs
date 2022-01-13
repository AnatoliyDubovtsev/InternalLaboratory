using Module10.Task1;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Module10.Tests.Task1.Tests
{
    public class BinarySearchTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 9, ExpectedResult = -1)]
        public int BinarySearch_ArrayInput_ReturnsExistsItem(IList<int> collection, int item)
            => Search.BinarySearch<int>(collection, item);

        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7" }, "2", ExpectedResult = 1)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7" }, "7", ExpectedResult = 6)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7" }, "9", ExpectedResult = -1)]
        public int BinarySearch_ArrayInput_ReturnsExistsItem(IList<string> collection, string item)
            => Search.BinarySearch<string>(collection, item);

        [TestCase(null, "1")]
        [TestCase(new string[] { "1" }, null)]
        public void BinarySearch_NullInput_ThrowsArgumentNullException(IList<string> collection, string item)
            => Assert.Throws<ArgumentNullException>(() => Search.BinarySearch<string>(collection, item));
        
        [TestCase(null, 1)]
        public void BinarySearch_NullInput_ThrowsArgumentNullException(IList<int> collection, int item)
            => Assert.Throws<ArgumentNullException>(() => Search.BinarySearch<int>(collection, item));

        [Test]
        public void BinarySearch_ListInput_ReturnsExistsItem()
        {
            //arrange
            var list = new List<int> { 1, 2, 3, 4 };
            var item = 2;
            var expected = 1;

            //act
            var result = Search.BinarySearch<int>(list, item);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
