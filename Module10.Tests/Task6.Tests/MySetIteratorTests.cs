using Module10.Task6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
