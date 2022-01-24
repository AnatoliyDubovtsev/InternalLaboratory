using Module10.Task7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Tests.Task7.Tests
{
    public class MyTreeTests
    {
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 4, 5, 7, 8, 10, 11, 12, 14 })]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 })]
        public void InorderTraversal_AfterAdd_ReturnsAllTreesItems(int[] collection, int[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            //act
            var actual = tree.InorderTraversal().ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 10, 8, 7, 5, 4, 11, 12, 14 })]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 10, 8, 7, 5, 4, 1, 3, 2, 6, 9, 11, 12, 14, 13 })]
        public void PreorderTraversal_AfterAdd_ReturnsAllTreesItems(int[] collection, int[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            //act
            var actual = tree.PreorderTraversal().ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 4, 5, 7, 8, 14, 12, 11, 10 })]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 2, 3, 1, 4, 6, 5, 7, 9, 8, 13, 14, 12, 11, 10})]
        public void PostorderTraversal_AfterAdd_ReturnsAllTreesItems(int[] collection, int[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            //act
            var actual = tree.PostorderTraversal().ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
