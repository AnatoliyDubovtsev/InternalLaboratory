using Module10.Task5;
using NUnit.Framework;
using System;

namespace Module10.Tests.Task5.Tests
{
    public class MyStackTests
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1 }, 1)]
        public void PushAndPeek_InputArrayOfIntegers_ReturnsHeadOfStack(int[] array, int expected)
        {
            //arrange
            var stack = new MyStack<int>();
            foreach(var item in array)
            {
                stack.Push(item);
            }

            //act
            var actual = stack.Peek();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        public void Pop_InputArrayOfIntegers_RemovesHeadElementAndReturnsIt(int[] array, int expected)
        {
            //arrange
            var stack = new MyStack<int>(array);

            //act
            var actual = stack.Pop();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 6, 7 }, 7)]
        [TestCase(new int[] { 1 }, 1, new int[] { 2 }, 2)]
        public void PushPopPushPeek_InputArrayOfIntegeres_ReturnsHeadOfStack(int[] initialArray, int popElements, int[] newArray, int expected)
        {
            //arrange
            var stack = new MyStack<int>(initialArray);
            for (int i = 0; i < popElements; i++)
            {
                _ = stack.Pop();
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                stack.Push(newArray[i]);
            }

            //act
            var actual = stack.Peek();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 8)]
        public void InternalArraySize_AfterPush(int[] array, int expected)
        {
            //arrange
            var stack = new MyStack<int>();
            foreach(var item in array)
            {
                stack.Push(item);
            }

            //act
            var actual = stack.InternalArraySize;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 8)]
        public void InternalArraySize_AfterPop_CreateCollectionUsingPush(int[] array, int popElements, int expected)
        {
            //arrange
            var stack = new MyStack<int>();
            foreach(var item in array)
            {
                stack.Push(item);
            }

            for (int i = 0; i < popElements; i++)
            {
                _ = stack.Pop();
            }

            //act
            var actual = stack.InternalArraySize;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 8)]
        public void InternalArraySize_AfterPop_CreateCollectionUsingCtor(int[] array, int popElements, int expected)
        {
            //arrange
            var stack = new MyStack<int>(array);
            for(int i = 0; i < popElements; i++)
            {
                _ = stack.Pop();
            }

            //act
            var actual = stack.InternalArraySize;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3 }, 4, false)]
        public void Contains_InputArrayOfIntegers_ReturnsBoolean(int[] array, int item, bool expected)
        {
            //arrange
            var stack = new MyStack<int>(array);

            //act
            var actual = stack.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_InputArrayOfStrings_WithoutNulls_NotNullItem_ReturnsBoolean()
        {
            //arrange
            var array = new string[] { "A", "B" };
            var stack = new MyStack<string>(array);
            var item = "B";
            var expected = true;

            //act
            var actual = stack.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_InputArrayOfStrings_WithoutNulls_NullItem_ReturnsBoolean()
        {
            //arrange
            var array = new string[] { "A", "B" };
            var stack = new MyStack<string>(array);
            var item = default(string);
            var expected = false;

            //act
            var actual = stack.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, true)]
        [TestCase(new int[] { 1 }, false)]
        public void IsEmpty_ReturnsBoolean(int[] array, bool expected)
        {
            //arrange
            var stack = new MyStack<int>(array);

            //act
            var actual = stack.IsEmpty();

            //assert
            Assert.AreEqual(expected, actual);
        }

        #region ThrowsExceptionTests

        [TestCase(-1)]
        public void MyStackCtor_InvalidCapacity_ThrowsArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MyStack<int>(capacity));

        [TestCase(null)]
        public void MyStackCtor_NullInputCollection_ThrowsArgumentNullException(int[] array)
            => Assert.Throws<ArgumentNullException>(() => new MyStack<int>(array));

        [Test]
        public void MyStackCtor_InputCollectionContainsNulls_ThrowsArgumentNullException()
        {
            string[] array = new string[] { "1", null };
            Assert.Throws<ArgumentNullException>(() => new MyStack<string>(array));
        }

        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        public void Push_IndexOutOfDefaultRange_ThrowsArgumentOutOfRangeException(int[] array, int defaultLength)
        {
            var stack = new MyStack<int>(defaultLength);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                foreach(var item in array)
                {
                    stack.Push(item);
                }
            });
        }

        [TestCase("A", null)]
        [TestCase(null)]
        public void Push_NullItem_ThrowsArgumentNullException(params string[] items)
        {
            var stack = new MyStack<string>();
            Assert.Throws<ArgumentNullException>(() =>
            {
                foreach(var item in items)
                {
                    stack.Push(item);
                }
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { }, 0)]
        public void Peek_EmptyCollection_ThrowsInvalidOperationException(int[] array, int popElements)
        {
            var stack = new MyStack<int>(array);
            for (int i = 0; i < popElements; i++)
            {
                _ = stack.Pop();
            }

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        #endregion
    }
}
