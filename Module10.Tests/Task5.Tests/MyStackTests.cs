using Module10.Task5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void InternalArraySize_AfterPop(int[] array, int popElements, int expected)
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
    }
}
