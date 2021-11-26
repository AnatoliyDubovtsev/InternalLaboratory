using NUnit.Framework;

namespace Module2.NUnitTests
{
    public class FilterDigitTests
    {
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 6, ExpectedResult = new int[] { 6, 68, 69 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, -5, 6, 7, 68, 69, 75, -15, 17 }, 5, ExpectedResult = new int[] { -5, 75, -15 })]
        [TestCase(new int[] { 1, 4, 2}, 6, ExpectedResult = new int[] { })]
        [TestCase(new int[] { }, 7, ExpectedResult = new int[] { })]
        public int[] FilterDigit_ReturnsResultArray(int[] arr, int digit)
            => Task6.FilterDigit(arr, digit);
    }
}
