using NUnit.Framework;

namespace Module4.Tests
{
    public class BinaryEuclideanAlgorithmTests 
    {
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(105, 210, 315, ExpectedResult = 105)]
        [TestCase(15, 30, 45, 90, 180, ExpectedResult = 15)]
        [TestCase(-1071, 462, ExpectedResult = 21)]
        [TestCase(-105, -210, -315, ExpectedResult = 105)]
        [TestCase(21, 21, 21, ExpectedResult = 21)]
        [TestCase(42, 84, 126, 252, ExpectedResult = 42)]
        public int BinaryEuclideanAlgorithm_FindGcd_ReturnsResult(params int[] numbers)
            => new Task2.BinaryEuclideanAlgorithm().FindGcd(numbers);
    }
}
