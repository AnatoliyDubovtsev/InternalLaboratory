using Module10.Task6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Tests.Task6.Tests
{
    public class MySetTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 7, 8, 9 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { })]
        public void IntersectWith_ReturnsResultArray(int[] basicCollection, int[] inputCollection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(basicCollection);

            //act
            set.IntersectWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { 1, 0 })]
        public void UnionWith_ReturnsResultArray(int[] basicCollection, int[] inputCollection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(basicCollection);

            //act
            set.UnionWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 7, 8, 9 }, new int[] { 3, 4, 5, 6 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { })]
        public void ExceptWith_ReturnsResultArray(int[] basicCollection, int[] inputCollection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(basicCollection);

            //act
            set.ExceptWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 7, 8, 9 }, new int[] { 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 }, new int[] { 0 }, new int[] { 1, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { })]
        public void SymmetricExceptWith_ReturnsResultArray(int[] basicCollection, int[] inputCollection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(basicCollection);

            //act
            set.SymmetricExceptWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
