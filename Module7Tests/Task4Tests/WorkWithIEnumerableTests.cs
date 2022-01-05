using Module7.Task4;
using NUnit.Framework;
using System.Collections.Generic;

namespace Module7Tests.Task4Tests
{
    public class WorkWithIEnumerableTests
    {
        [Test]
        public void UniqueInOrder_ListOfIntegersInput_ReturnsResultListWithIntType()
        {
            //arrange
            var collection1 = new List<int>() { 1, 2, 3, 4, 3, 2, 1 };
            var expected1 = new List<int>() { 1, 2, 3, 4, 3, 2, 1 };
            var collection2 = new List<int>() { 1, 2, 1, 1, 1, 3, 3, 3, 1, 5 };
            var expected2 = new List<int>() { 1, 2, 1, 3, 1, 5 };
            var collection3 = new List<int>() { 1, 2, 3, 3, 3, 2, 1 };
            var expected3 = new List<int>() { 1, 2, 3, 2, 1 };

            //act
            var result1 = WorkWithIEnumerable.UniqueInOrder<int>(collection1);
            var result2 = WorkWithIEnumerable.UniqueInOrder<int>(collection2);
            var result3 = WorkWithIEnumerable.UniqueInOrder<int>(collection3);

            //assert
            CollectionAssert.AreEqual(expected1, result1);
            CollectionAssert.AreEqual(expected2, result2);
            CollectionAssert.AreEqual(expected3, result3);
        }

        [TestCase("12333432221", "1234321")]
        [TestCase("AAAABBBCCDAABBB", "ABCDAB")]
        [TestCase("ABBCcAD", "ABCcAD")]
        public void UniqueInOrder_StringInput_ReturnsResultListWithCharType(string input, string expected)
        {
            var result = WorkWithIEnumerable.UniqueInOrder<char>(input);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
