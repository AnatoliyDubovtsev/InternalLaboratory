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
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 10, 8, 7, 5, 4, 11, 12, 14 }, TraversalType.Preorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 10, 8, 7, 5, 4, 1, 3, 2, 6, 9, 11, 12, 14, 13 }, TraversalType.Preorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 4, 5, 7, 8, 10, 11, 12, 14 }, TraversalType.Inorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, TraversalType.Inorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 4, 5, 7, 8, 14, 12, 11, 10 }, TraversalType.Postorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 2, 3, 1, 4, 6, 5, 7, 9, 8, 13, 14, 12, 11, 10}, TraversalType.Postorder)]
        public void Traversal_AfterAdd_ReturnsAllTreesItems(int[] collection, int[] expected, TraversalType traversalType)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actual = new int[collection.Length];

            //act
            var items = tree.Traversal(traversalType);
            foreach(var item in items)
            {
                actual[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 10, 7, 5, 98, 4, 353, 2, 1, 7, 8, 9 }, TraversalType.Inorder, new int[] { 1, 2, 4, 5, 7, 8, 9, 10, 98, 353 })]
        [TestCase(1, new int[] { 1 }, TraversalType.Postorder, new int[] { 1 })]
        public void Ctor_WithFirstNode_AddMethod_ReturnsAllItems(int first, int[] collection, TraversalType traversalType, int[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>(first);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var actual = new int[expected.Length];
            var index = 0;

            //act
            foreach (var item in tree.Traversal(traversalType))
            {
                actual[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
