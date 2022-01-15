using Module10.Task4;
using NUnit.Framework;
using System;

namespace Module10.Tests.Task4.Tests
{
    public class MyQueueTests
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        public void EnqueueMethod_InputArrayOfInt_ReturnsHeadItemUsingPeekMethod(int[] array, int expected)
        {
            //arrange
            var queue = new MyQueue<int>();
            foreach(var item in array)
            {
                queue.Enqueue(item);
            }

            //act
            var actual = queue.Peek();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 2, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9, 9)]
        public void DequeueMethod_InputArrayOfInt_ReturnsHeadItemAfterDequeueMethod(int[] array, int dequeueItems, int expected)
        {
            //arrange
            var queue = new MyQueue<int>();
            foreach (var item in array)
            {
                queue.Enqueue(item);
            }

            //act
            int actual = 0;
            for(int i = 0; i < dequeueItems; i++)
            {
                actual = queue.Dequeue();
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 16)]
        public void InternalArraySizeTests_AfterEnqueue(int[] array, int expectedSize)
        {
            //arrange
            var queue = new MyQueue<int>();
            foreach(var item in array)
            {
                queue.Enqueue(item);
            }

            //act
            var actualSize = queue.InternalArraySize;

            //assert
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 16)]
        public void InternalArraySizeTests_AfterEnqueueAndDequeue(int[] array, int dequeueItems, int expectedSize)
        {
            //arrange
            var queue = new MyQueue<int>();
            foreach (var item in array)
            {
                queue.Enqueue(item);
            }

            for(int i = 0; i < dequeueItems; i++)
            {
                _ = queue.Dequeue();
            }

            //act
            var actualSize = queue.InternalArraySize;

            //assert
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3 }, 4, false)]
        public void Contains_ArrayOfIntegersInput_ReturnsBoolean(int[] array, int item, bool expected)
        {
            //arrange
            var queue = new MyQueue<int>(array);

            //act
            var actual = queue.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_ArrayOfStringsWithoutNullsInput_ItemParameterIsNotNull_ReturnsBoolean()
        {
            //arrange
            var queue = new MyQueue<string>(new string[] { "A", "B" });
            var item = "A";
            var expected = true;

            //act
            var actual = queue.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_ArrayOfStringsWithNullsInput_ItemParameterIsNull_ReturnsBoolean()
        {
            //arrange
            var queue = new MyQueue<string>(new string[] { "A", null });
            var item = default(string);
            var expected = true;

            //act
            var actual = queue.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_ArrayOfStringsWithNullsInput_ItemParameterIsNotNull_ReturnsBoolean()
        {
            //arrange
            var queue = new MyQueue<string>(new string[] { "A", null });
            var item = "B";
            var expected = false;

            //act
            var actual = queue.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { }, true)]
        public void IsEmpty_ReturnsBoolean(int[] array, bool expected)
        {
            //arrange
            var queue = new MyQueue<int>(array);

            //act
            var actual = queue.IsEmpty();

            //assert
            Assert.AreEqual(expected, actual);
        }


        #region ThrowsExceptionTests
        [TestCase(new int[] { })]
        public void PeekMethod_InputEmptyArray_ThrowsInvalidOperationException(int[] array)
        {
            var queue = new MyQueue<int>(array);
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
        
        [Test]
        public void PeekMethod_InputArrayOfNulls_ThrowsInvalidOperationException()
        {
            var queue = new MyQueue<string>(new string[] { null });
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void PeekMethod_EmptyConstructor_ThrowsInvalidOperationException()
        {
            var queue = new MyQueue<string>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void NullParameterInConstructor_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MyQueue<int>(null));

        [TestCase(-1)]
        public void CapacityParameterInConstructorIsLessThanZert_ThrowsArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MyQueue<int>(capacity));

        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        public void EnqueueMethod_OverflowsDefaultArraysSize_ThrowsArgumentOutOfRangeException(int[] array, int defaultCapacity)
        {
            var queue = new MyQueue<int>(defaultCapacity);
            Assert.Throws<ArgumentOutOfRangeException>(() => { 
                for (int i = 0; i < array.Length; i++)
                {
                    queue.Enqueue(array[i]);
                }
            });
        }
        #endregion
    }
}
