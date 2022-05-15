using Module10.Task3;
using NUnit.Framework;
using System;

namespace Module10.Tests.Task3.Tests
{
    public class FibonacciTests
    {
        [TestCase(10, new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(1, new int[] { 1 })]
        [TestCase(0, new int[] { })]
        [TestCase(-1, new int[] { })]
        public void Numbers_InputQuantityOfNumbers_ReturnsFibonacciSequence(int quantity, int[] expected)
        {
            //arrange
            var Fibonacci = new Fibonacci(quantity);
            int[] result = Array.Empty<int>();
            if (quantity >= 0)
            {
                result = new int[quantity];
            }
            
            var index = 0;

            //act
            foreach(var number in Fibonacci)
            {
                result[index++] = number;
            }

            //assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
