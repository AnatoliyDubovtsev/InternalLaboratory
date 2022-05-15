#pragma warning disable S4136
using Module10.Task6;
using NUnit.Framework;
using System;
using System.Collections;

namespace Module10.Tests.Task6.Tests
{
    public class MySetTests
    {
        #region ReferenceTypeInput_TestCases
        public static IEnumerable Add_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C", "D", "D", "A", "a", "B" }, new string[] { "A", "B", "C", "D", "a" });
                yield return new TestCaseData(new string[] { "A", "A", "A" }, new string[] { "A" });
            }
        }

        public static IEnumerable Remove_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C" }, "A", new string[] { "B", "C" }, true);
                yield return new TestCaseData(new string[] { "A" }, "B", new string[] { "A" }, false);
                yield return new TestCaseData(new string[] { "A" }, "A", new string[] { }, true);
                yield return new TestCaseData(new string[] { "A" }, "a", new string[] { "A" }, false);
            }
        }

        public static IEnumerable Contains_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C" }, "A", true);
                yield return new TestCaseData(new string[] { "A", "B", "C" }, "a", false);
                yield return new TestCaseData(new string[] { }, "A", false);
                yield return new TestCaseData(new string[] { "A" }, "A", true);
                yield return new TestCaseData(new string[] { "a" }, "A", false);
            }
        }

        public static IEnumerable IntersectWith_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C", "a", "b", "c" },
                    new string[] { "A", "b", "D", "d", "G", "g" }, new string[] { "A", "b" });
                yield return new TestCaseData(new string[] { "A" }, new string[] { "g" }, new string[] { });
            }
        }

        public static IEnumerable UnionWith_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C", "a", "b", "c" }, new string[] { "C", "c", "D", "d", "E", "e" },
                    new string[] { "A", "B", "C", "a", "b", "c", "D", "d", "E", "e" });
                yield return new TestCaseData(new string[] { "A" }, new string[] { "A" }, new string[] { "A" });
                yield return new TestCaseData(new string[] { "a" }, new string[] { "A", "B" }, new string[] { "a", "A", "B" });
            }
        }

        public static IEnumerable ExceptWith_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C", "a", "b", "c" }, new string[] { "B", "b", "C", "c", "D", "d", "E", "e" },
                    new string[] { "A", "a" });
                yield return new TestCaseData(new string[] { "A" }, new string[] { "A" }, new string[] { });
                yield return new TestCaseData(new string[] { "a" }, new string[] { "A", "B" }, new string[] { "a" });
            }
        }

        public static IEnumerable SymmetricExceptWith_ReferenceTypeInput_TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "A", "B", "C", "a", "b", "c" }, new string[] { "B", "b", "C", "c", "D", "d", "E", "e" },
                    new string[] { "A", "a", "D", "d", "E", "e" });
                yield return new TestCaseData(new string[] { "A" }, new string[] { "A" }, new string[] { });
                yield return new TestCaseData(new string[] { "a" }, new string[] { "A", "B" }, new string[] { "a", "A", "B" });
            }
        }

        #endregion

        #region Methods_ValueTypeInput
        [Test]
        public void Ctor_Empty_Returns_InternalLength4_Count0()
        {
            //arrange
            var set = new MySet<int>();
            var expectedCount = 0;
            var expectedInternalArrayLength = 4;

            //act
            var actualCount = set.Count;
            var actualInternalArrayLength = set.InternalArrayLength;

            //assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedInternalArrayLength, actualInternalArrayLength);
        }

        [TestCase(new int[] { 1 }, new int[] { 1 }, 1, 4)]
        [TestCase(new int[] { }, new int[] { }, 0, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 5, 8)]
        public void Ctor_Empty_AddMethod_ReturnsAllElements_Count_InternalLength(int[] collection, int[] expectedCollection,
            int expectedCount, int expectedInternalLength)
        {
            //arrange
            var set = new MySet<int>();
            foreach(var item in collection)
            {
                set.Add(item);
            }

            //act
            var actualCollection = set.ToArray();
            var actualCount = set.Count;
            var actualInternalLength = set.InternalArrayLength;

            //assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedInternalLength, actualInternalLength);
        }

        [TestCase(new int[] { 1 }, new int[] { }, 1, 0, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 }, 3, 4, 4 )]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 5, 6 }, 4, 5, 8)]
        public void Ctor_Empty_Add_Remove_ReturnsAllElements_Count_InternalLength(int[] collection, int[] expectedCollection,
            int itemToRemove, int expectedCount, int expectedInternalLength)
        {
            //arrange
            var set = new MySet<int>();
            foreach(var item in collection)
            {
                set.Add(item);
            }

            set.Remove(itemToRemove);

            //act
            var actualCollection = set.ToArray();
            var actualCount = set.Count;
            var actualInternalLength = set.InternalArrayLength;

            //assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedInternalLength, actualInternalLength);
        }

        [TestCase(new int[] { 1, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1 })]
        public void Add_ReturnsOnlyUniqueElements(int[] collection, int[] expected)
        {
            //arrange
            var set = new MySet<int>(collection);

            //actual
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, false)]
        public void Remove_ReturnsBoolean(int[] collection, int item, bool expected)
        {
            //arrange
            var set = new MySet<int>(collection);

            //act
            var actual = set.Remove(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4)]
        public void Clear_ReturnsCount0_InternalSize4(int[] collection, int expectedCount, int expectedInternalLength)
        {
            //arrange
            var set = new MySet<int>(collection);

            //act
            set.Clear();
            var actualCount = set.Count;
            var actualInternalLength = set.InternalArrayLength;

            //assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedInternalLength, actualInternalLength);
        }

        [TestCase(new int[] { }, 0, false)]
        [TestCase(new int[] { 1 }, 0, false)]
        [TestCase(new int[] { 1 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, true)]
        public void Contains_ReturnsBoolean(int[] collection, int item, bool expected)
        {
            //arrange
            var set = new MySet<int>(collection);

            //act
            var actual = set.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

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
        #endregion

        #region Methods_ReferenceTypeInput
        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.Add_ReferenceTypeInput_TestCases))]
        public void Add_ReturnsOnlyUniqueElements(string[] collection, string[] expected)
        {
            //arrange
            var set = new MySet<string>(collection);

            //actual
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.Remove_ReferenceTypeInput_TestCases))]
        public void Remove_ReturnsBoolean(string[] collection, string item, string[] expectedCollection, bool expectedBoolean)
        {
            //arrange
            var set = new MySet<string>(collection);

            //act
            var actualBoolean = set.Remove(item);
            var actualCollection = set.ToArray();

            //assert
            Assert.AreEqual(expectedBoolean, actualBoolean);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.Contains_ReferenceTypeInput_TestCases))]
        public void Contains_ReturnsBoolean(string[] collection, string item, bool expected)
        {
            //arrange
            var set = new MySet<string>(collection);

            //act
            var actual = set.Contains(item);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.IntersectWith_ReferenceTypeInput_TestCases))]
        public void IntersectWith_ReturnsResultArray(string[] basicCollection, string[] inputCollection, string[] expected)
        {
            //arrange
            var set = new MySet<string>(basicCollection);

            //act
            set.IntersectWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.UnionWith_ReferenceTypeInput_TestCases))]
        public void UnionWith_ReturnsResultArray(string[] basicCollection, string[] inputCollection, string[] expected)
        {
            //arrange
            var set = new MySet<string>(basicCollection);

            //act
            set.UnionWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.ExceptWith_ReferenceTypeInput_TestCases))]
        public void ExceptWith_ReturnsResultArray(string[] basicCollection, string[] inputCollection, string[] expected)
        {
            //arrange
            var set = new MySet<string>(basicCollection);

            //act
            set.ExceptWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(MySetTests), nameof(MySetTests.SymmetricExceptWith_ReferenceTypeInput_TestCases))]
        public void SymmetricExceptWith_ReturnsResultArray(string[] basicCollection, string[] inputCollection, string[] expected)
        {
            //arrange
            var set = new MySet<string>(basicCollection);

            //act
            set.SymmetricExceptWith(inputCollection);
            var actual = set.ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region ExceptionsChecking
        [TestCase(null)]
        public void Ctor_NullParameter_ThrowsArgumentNullException(int[] collection)
            => Assert.Throws<ArgumentNullException>(() => new MySet<int>(collection));

        [Test]
        public void Ctor_NullItemsInCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", null, "C" };
            Assert.Throws<ArgumentNullException>(() => new MySet<string>(collection));
        }

        [Test]
        public void Add_NullItem_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.Add(null));
        }

        [Test]
        public void Remove_NullItem_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.Remove(null));
        }

        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.Contains(null));
        }

        [Test]
        public void IntersectWith_NullCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.IntersectWith(null));
        }

        [Test]
        public void ExceptWith_NullCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.ExceptWith(null));
        }

        [Test]
        public void SymmetricExceptWith_NullCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.SymmetricExceptWith(null));
        }

        [Test]
        public void UnionWith_NullCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            Assert.Throws<ArgumentNullException>(() => set.UnionWith(null));
        }

        [Test]
        public void ExceptWith_NullItemInCollection_ThrowsArgumentNullException()
        {
            var basicCollection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(basicCollection);
            var inputCollection = new string[] { "a", "B", null };
            Assert.Throws<ArgumentNullException>(() => set.ExceptWith(inputCollection));
        }

        [Test]
        public void SymmetricExceptWith_NullItemInCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            var inputCollection = new string[] { "a", "B", null };
            Assert.Throws<ArgumentNullException>(() => set.SymmetricExceptWith(inputCollection));
        }

        [Test]
        public void UnionWith_NullItemInCollection_ThrowsArgumentNullException()
        {
            var collection = new string[] { "A", "B", "C" };
            var set = new MySet<string>(collection);
            var inputCollection = new string[] { "a", "B", null };
            Assert.Throws<ArgumentNullException>(() => set.UnionWith(inputCollection));
        }
        #endregion
    }
}
