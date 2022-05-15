using Module10.Task6;
using NUnit.Framework;

namespace Module10.Tests.Task6.Tests
{
    public class MySetIteratorTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Foreach_ReturnsAllElements(int[] collection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(collection);
            var actual = new int[collection.Length];
            var index = 0;

            //act
            foreach(var item in set)
            {
                actual[index++] = item;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void ForeachAfterRemove_ReturnsAllElements(int[] collection, int itemId, int[] expected)
        {
            //arrange
            var set = new MySet<int>(collection);
            var actual = new int[collection.Length - 1];
            set.Remove(collection[itemId]);
            var index = 0;

            //act
            foreach (var item in set)
            {
                actual[index++] = item;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
