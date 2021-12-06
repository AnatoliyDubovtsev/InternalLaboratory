using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Common.Tests
{
    [TestFixture(new int[] { 1, 2, 3 })]
    [TestFixture(new int[] {})]
    [TestFixture(new int[] { 1 })]
    public class ShowCollectionItemsTests
    {
        private readonly int[] inputCollection;
        private readonly string expectedResult;

        public ShowCollectionItemsTests(int[] arr)
        {
            inputCollection = arr;
            expectedResult = CreateExpectedString<int>(arr);
        }

        public static string CreateExpectedString<T>(T[] arr)
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0; i < arr.Length; i++)
            {
                stringBuilder.Append(i + " " + arr[i] + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        [Test]
        public void ShowCollectionItem_ReturnsIndexAndItem()
        {
            //arrange
            using var writer = new StringWriter();
            Console.SetOut(writer);

            //act
            CommonMethods.ShowCollectionItems<int>(inputCollection);
            var actual = writer.ToString();

            //assert
            Assert.AreEqual(actual, expectedResult);
        }

        [TestCase(null)]
        public void ShowCollectionItem_ThrowsArgumentNullException(int[] arr)
            => Assert.Throws<ArgumentNullException>(() => CommonMethods.ShowCollectionItems<int>(arr));
    }
}