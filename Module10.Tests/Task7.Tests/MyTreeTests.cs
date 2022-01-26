using Module10.Task7;
using Module10.Task7.Objects;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Module10.Tests.Task7.Tests
{
    public class MyTreeTests
    {
        #region IntegerTestData
        public static IEnumerable Add_Integer_TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, null, TraversalType.Preorder, new int[] { 10, 8, 7, 5, 4, 11, 12, 14 });
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, null,
                    TraversalType.Preorder, new int[] { 10, 8, 7, 5, 4, 1, 3, 2, 6, 9, 11, 12, 14, 13 });
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, null, TraversalType.Inorder, new int[] { 4, 5, 7, 8, 10, 11, 12, 14 });
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 95, 85, 83, 86, 93, 92, 94, 97, 98, 96 },
                    null, TraversalType.Inorder, new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100, 120 });
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, null, TraversalType.Inorder,
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 }, null, TraversalType.Postorder, new int[] { 4, 5, 7, 8, 14, 12, 11, 10 });
                yield return new TestCaseData(new int[] { 10, 8, 11, 12, 9, 14, 13, 7, 5, 4, 6, 1, 3, 2 }, null, TraversalType.Postorder,
                    new int[] { 2, 3, 1, 4, 6, 5, 7, 9, 8, 13, 14, 12, 11, 10 });
            }
        }

        public static IEnumerable Remove_Integer_TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 95, null, TraversalType.Inorder,
                    new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 96, 97, 98, 100, 120 }, true);
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 90, null, TraversalType.Inorder,
                    new int[] { 70, 80, 83, 85, 86, 92, 93, 94, 95, 96, 97, 98, 100, 120 }, true);
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 120, null, TraversalType.Inorder,
                    new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100 }, true);
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 100, null, TraversalType.Inorder,
                    new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 120 }, true);
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 85, 83, 86, 95, 93, 92, 94, 97, 98, 96 }, 180, null, TraversalType.Inorder,
                    new int[] { 70, 80, 83, 85, 86, 90, 92, 93, 94, 95, 96, 97, 98, 100, 120 }, false);
                yield return new TestCaseData(new int[] { 100, 80, 120, 70, 90, 130 }, 120, null, TraversalType.Inorder, new int[] { 70, 80, 90, 100, 130 }, true);
                yield return new TestCaseData(new int[] { 90, 100, 80, 120, 70, 130 }, 80, null, TraversalType.Inorder, new int[] { 70, 90, 100, 120, 130 }, true);
                yield return new TestCaseData(new int[] { 90, 100, 80, 120, 70, 130 }, 70, null, TraversalType.Inorder, new int[] { 80, 90, 100, 120, 130 }, true);
                yield return new TestCaseData(new int[] { 90, 100, 80, 70, 120, 75, 130 }, 70, null, TraversalType.Inorder,
                    new int[] { 75, 80, 90, 100, 120, 130 }, true);
                yield return new TestCaseData(new int[] { 90, 100, 80, 120, 70, 130, 125 }, 130, null, TraversalType.Inorder,
                    new int[] { 70, 80, 90, 100, 120, 125 }, true);
                yield return new TestCaseData(new int[] { 90, 100, 80, 120, 70, 130, 125 }, 10, null, TraversalType.Inorder,
                    new int[] { 70, 80, 90, 100, 120, 125, 130 }, false);
            }
        }

        public static IEnumerable Ctor_Integer_TestCases
        {
            get
            {
                yield return new TestCaseData(5, new int[] { 10, 7, 5, 98, 4, 353, 2, 1, 7, 8, 9 }, null, TraversalType.Inorder,
                    new int[] { 1, 2, 4, 5, 7, 8, 9, 10, 98, 353 });
                yield return new TestCaseData(1, new int[] { 1 }, null, TraversalType.Postorder, new int[] { 1 });
            }
        }
        #endregion

        #region StringTestData
        public static IEnumerable Add_String_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "Bb", "c", "C", "cd", "d", "D" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, null, TraversalType.Preorder,
                    new string[] { "C", "abc", "Bb", "Abc", "b", "c", "d", "cd", "D" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, null, TraversalType.Postorder,
                    new string[] { "b", "Abc", "c", "Bb", "abc", "cd", "D", "d", "C" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "D", "abc", "b", "c", "cd", "d" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, new Comparators<string>(), TraversalType.Preorder,
                    new string[] { "C", "Bb", "Abc", "abc", "D", "c", "b", "d", "cd" });
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d", "D", "cd" }, new Comparators<string>(), TraversalType.Postorder,
                    new string[] { "Abc", "Bb", "D", "b", "cd", "d", "c", "abc", "C" });
            }
        }

        public static IEnumerable Remove_String_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "C", null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "Bb", "c", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "d", null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "Bb", "c", "C" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Bb", null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "c", "C", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "c", null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "Bb", "C", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Z", null, TraversalType.Inorder,
                    new string[] { "abc", "Abc", "b", "Bb", "c", "C", "d" }, false);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "C", new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "abc", "b", "c", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "d", new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "c" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Bb", new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "C", "abc", "b", "c", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "c", new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "d" }, true);
                yield return new TestCaseData(new string[] { "C", "abc", "Bb", "Abc", "c", "b", "d" }, "Z", new Comparators<string>(), TraversalType.Inorder,
                    new string[] { "Abc", "Bb", "C", "abc", "b", "c", "d" }, false);
            }
        }
        #endregion

        #region BookClassTestData
        public static IEnumerable Add_BookClass_TestCases
        {
            get
            {
                yield return new TestCaseData(new Book[]
                    { 
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, null, TraversalType.Inorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("B", "B", 2010, 10), new Book("F", "F", 1997, 12), new Book("A", "A", 2000, 15),
                        new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50)
                    });
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, null, TraversalType.Preorder, new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12),
                        new Book("C", "C", 1990, 30), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27), new Book("D", "D", 2005, 50)
                    });
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, null, TraversalType.Postorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("B", "B", 2010, 10), new Book("H", "H", 1980, 27),
                        new Book("G", "G", 2001, 25), new Book("D", "D", 2005, 50), new Book("C", "C", 1990, 30), new Book("A", "A", 2000, 15)
                    });

                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Comparators<Book>(), TraversalType.Inorder, new Book[]
                    {
                        new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30), new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12),
                        new Book("A", "A", 2000, 15), new Book("G", "G", 2001, 25), new Book("D", "D", 2005, 50), new Book("B", "B", 2010, 10)
                    });
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Comparators<Book>(), TraversalType.Preorder, new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("C", "C", 1990, 30), new Book("H", "H", 1980, 27), new Book("E", "E", 1995, 5),
                        new Book("F", "F", 1997, 12), new Book("B", "B", 2010, 10), new Book("D", "D", 2005, 50), new Book("G", "G", 2001, 25)
                    });
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Comparators<Book>(), TraversalType.Postorder, new Book[]
                    {
                        new Book("H", "H", 1980, 27), new Book("F", "F", 1997, 12), new Book("E", "E", 1995, 5), new Book("C", "C", 1990, 30),
                        new Book("G", "G", 2001, 25), new Book("D", "D", 2005, 50), new Book("B", "B", 2010, 10), new Book("A", "A", 2000, 15)
                    });
            }
        }

        public static IEnumerable Remove_BookClass_TestCases
        {
            get
            {
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Book("C", "C", 1990, 30), null, TraversalType.Inorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("B", "B", 2010, 10), new Book("F", "F", 1997, 12), new Book("A", "A", 2000, 15),
                        new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27), new Book("D", "D", 2005, 50)
                    }, true);
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Book("D", "D", 2005, 50), null, TraversalType.Inorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("B", "B", 2010, 10), new Book("F", "F", 1997, 12), new Book("A", "A", 2000, 15),
                        new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30)
                    }, true);
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Book("B", "B", 2010, 10), null, TraversalType.Inorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("A", "A", 2000, 15), new Book("G", "G", 2001, 25),
                        new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50)
                    }, true);
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Book("E", "E", 1995, 5), null, TraversalType.Inorder, new Book[]
                    {
                        new Book("B", "B", 2010, 10), new Book("F", "F", 1997, 12), new Book("A", "A", 2000, 15), new Book("G", "G", 2001, 25),
                        new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50)
                    }, true);
                yield return new TestCaseData(new Book[]
                    {
                        new Book("A", "A", 2000, 15), new Book("B", "B", 2010, 10), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50),
                        new Book("E", "E", 1995, 5), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25), new Book("H", "H", 1980, 27)
                    }, new Book("A", "A", 2000, 15), null, TraversalType.Inorder, new Book[]
                    {
                        new Book("E", "E", 1995, 5), new Book("B", "B", 2010, 10), new Book("F", "F", 1997, 12), new Book("G", "G", 2001, 25),
                        new Book("H", "H", 1980, 27), new Book("C", "C", 1990, 30), new Book("D", "D", 2005, 50)
                    }, true);
            }
        }
        #endregion

        #region PointStructureTestData
        #endregion

        #region CorrectInputTests
        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Add_Integer_TestCases))]
        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Add_String_TestCases))]
        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Add_BookClass_TestCases))]
        public void Traversal_AfterAdd_ReturnsAllTreesItems<T>(T[] collection, IComparer<T> comparator, TraversalType traversalType, T[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<T>(comparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actual = new T[collection.Length];

            //act
            var items = tree.Traversal(traversalType);
            foreach (var item in items)
            {
                actual[index++] = item.Value;
            }

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Remove_Integer_TestCases))]
        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Remove_String_TestCases))]
        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Remove_BookClass_TestCases))]
        public void Remove_ReturnsBoolean<T>(T[] collection, T deleteItem, IComparer<T> comparator, TraversalType traversalType, T[] expected,
            bool expectedBoolean)
        {
            //arrange
            var tree = new MyBinarySearchTree<T>(comparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var index = 0;
            var actualCollection = new T[expected.Length];

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

        [TestCaseSource(typeof(MyTreeTests), nameof(MyTreeTests.Ctor_Integer_TestCases))]
        public void Ctor_WithFirstNode_AddMethod_ReturnsAllItems<T>(T first, T[] collection, IComparer<T> comparator, TraversalType traversalType, T[] expected)
        {
            //arrange
            var tree = new MyBinarySearchTree<T>(first, comparator);
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            var actual = new T[expected.Length];
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

        #region TestingExceptions
        [Test]
        public void Ctor_NullValue_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MyBinarySearchTree<string>(default(string)));

        [Test]
        public void Add_NullValue_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MyBinarySearchTree<string>().Add(null));

        [Test]
        public void Remove_NullValue_ReturnsFalse()
            => Assert.False(new MyBinarySearchTree<string>().Remove(null));
        #endregion
    }
}
