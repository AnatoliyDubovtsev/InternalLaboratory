using Module10.Task5;
using NUnit.Framework;

namespace Module10.Tests.Task5.Tests
{
    public class MyStackIteratorTests
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void Foreach_ReturnsAllElements(int[] array, int[] expectedCollection)
        {
            //arrange
            var stack = new MyStack<int>(array);
            var actualCollection = new int[array.Length];
            var index = 0;

            //act
            foreach(var item in stack)
            {
                actualCollection[index++] = item;
            }

            //assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
