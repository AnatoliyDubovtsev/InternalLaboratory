using Module10.Task7;
using Module10.Task7.Objects;
using NUnit.Framework;
using System;
using System.Collections;

namespace Module10.Tests.Task7.Tests
{
    public class MyTreeTests
    {
        #region StringTestData
        public static IEnumerable Add_String_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, true, TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "c", "d" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, true, TraversalType.Preorder,
                    new string[] { "C", "Bb", "Abc", "abc", "c", "b", "d" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, true, TraversalType.Preorder,
                    new string[] { "C", "Bb", "Abc", "abc", "c", "b", "d" });
            }
        }

        public static IEnumerable Remove_String_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "C", true, TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "abc", "b", "c", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "d", true, TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "c" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Bb", true, TraversalType.Inorder,
                    new string[] { "Abc", "C", "abc", "b", "c", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "c", true, TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Z", true, TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "c", "d" }, false);
            }
        }
        #endregion

        #region BookClassTestData
        #endregion

        #region PointStructureTestData
        #endregion

        #region BasicMethodsUsingIntegersInput
        [TestCase(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 95, TraversalType.Inorder,
            new int[] {70, 80, 83, 85, 86, 90, 92, 93, 94, 96, 97, 98, 100, 120 }, true)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 90, TraversalType.Inorder,
            new int[] { 70, 80, 83, 85, 86, 92, 93, 94, 95, 96, 97, 98, 100, 120 }, true)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 120, TraversalType.Inorder,
            new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100 }, true)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 100, TraversalType.Inorder,
            new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 120 }, true)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 180, TraversalType.Inorder,
            new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100, 120 }, false)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 130 }, 120, TraversalType.Inorder, new int[] { 70, 80, 90, 100, 130 }, true)]
        [TestCase(new int[] { 90, 100, 80, 120, 70, 130 }, 80, TraversalType.Inorder, new int[] { 70, 90, 100, 120, 130 }, true)]
        [TestCase(new int[] { 90, 100, 80, 120, 70, 130 }, 70, TraversalType.Inorder, new int[] { 80, 90, 100, 120, 130 }, true)]
        [TestCase(new int[] { 90, 100, 80, 70, 120, 75, 130 }, 70, TraversalType.Inorder, new int[] { 75, 80, 90, 100, 120, 130 }, true)]
        [TestCase(new int[] { 90, 100, 80, 120, 70, 130, 125 }, 130, TraversalType.Inorder, new int[] { 70, 80, 90, 100, 120, 125 }, true)]
        [TestCase(new int[] { 90, 100, 80, 120, 70, 130, 125 }, 10, TraversalType.Inorder, new int[] { 70, 80, 90, 100, 120, 125, 130 }, false)]
        public void Remove_ReturnsBoolean(int[] collection, int deleteItem, TraversalType traversalType, int[] expected, bool expectedBoolean)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actualCollection = new int[expected.Length];

            //act
            var actualBoolean = tree.Remove(deleteItem);
            var items = tree.Traversal(traversalType);
            foreach (var item in items)
            {
                actualCollection[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actualCollection);
            Assert.AreEqual(expectedBoolean, actualBoolean);
        }

        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 10, 8, 7, 5, 4, 11, 12, 14 }, TraversalType.Preorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, new int[] { 10, 8, 7, 5, 4, 1, 3, 2, 6, 9, 11, 12, 14, 13 }, TraversalType.Preorder)]
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, new int[] { 4, 5, 7, 8, 10, 11, 12, 14 }, TraversalType.Inorder)]
        [TestCase(new int[] { 100, 80, 120, 70, 90, 95, 85, 83, 86, 93, 92, 94, 97, 98, 96 },
            new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100, 120 }, TraversalType.Inorder)]
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
        #endregion

        #region BasicMethodsUsingStringInput
        
        /*public void Remove_ReturnsBoolean(string[] collection, string deleteItem, bool isTreesComparator, TraversalType traversalType,
            string[] expected, bool expectedBoolean)
        {
            //arrange
            var tree = new MyBinarySearchTree<string>(isTreesComparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actualCollection = new string[expected.Length];

            //act
            var actualBoolean = tree.Remove(deleteItem);
            var items = tree.Traversal(traversalType);
            foreach (var item in items)
            {
                actualCollection[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actualCollection);
            Assert.AreEqual(expectedBoolean, actualBoolean);
        }

        
        public void Traversal_AfterAdd_ReturnsAllTreesItems(string[] collection, string[] expected, bool isTreesComparator, TraversalType traversalType)
        {
            //arrange
            var tree = new MyBinarySearchTree<string>(isTreesComparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actual = new string[collection.Length];

            //act
            var items = tree.Traversal(traversalType);
            foreach (var item in items)
            {
                actual[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        
        public void Ctor_WithFirstNode_AddMethod_ReturnsAllItems(string first, string[] collection, bool isTreesComparator, TraversalType traversalType, string[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<string>(first, isTreesComparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var actual = new string[expected.Length];
            var index = 0;

            //act
            foreach (var item in tree.Traversal(traversalType))
            {
                actual[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }*/
        #endregion

        #region BasicMethodsUsingBookClass
        #endregion

        #region BasicMethodsUsingPointStructure
        #endregion

        #region TestingExceptions
        [Test]
        public void Ctor_NullValue_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MyBinarySearchTree<string>(null));

        [Test]
        public void Add_NullValue_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MyBinarySearchTree<string>().Add(null));

        [Test]
        public void Remove_NullValue_ReturnsFalse()
            => Assert.False(new MyBinarySearchTree<string>().Remove(null));
        #endregion
    }
}
