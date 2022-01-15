using Module10.Task4;
using NUnit.Framework;

namespace Module10.Tests.Task4.Tests
{
    public class MyQueueIteratorTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Foreach_ReturnsAllElements(int[] array, int[] expected)
        {
            //arrange
            var queue = new MyQueue<int>(array);
            var actual = new int[queue.Count];
            var index = 0;

            //act
            foreach(var item in queue)
            {
                actual[index++] = item;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
