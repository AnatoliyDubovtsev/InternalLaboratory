using NUnit.Framework;

namespace Module4.Tests
{
    public class EuclideanAlgorithmTests
    {
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(105, 210, 315, ExpectedResult = 105)]
        [TestCase(15, 30, 45, 90, 180, ExpectedResult = 15)]
        [TestCase(-1071, 462, ExpectedResult = 21)]
        [TestCase(-105, -210, -315, ExpectedResult = 105)]
        [TestCase(21, 21, 21, ExpectedResult = 21)]
        [TestCase(42, 84, 126, 252, ExpectedResult = 42)]
        [TestCase(1375800, 9876090, 3859650, 456000, 756890, 957000, ExpectedResult = 10)]
        public int EuclideanAlgorithm_FindGcd_ReturnsResult(params int[] numbers)
            => new Task2.EuclideanAlgorithm().FindGcd(numbers);
    }
}
