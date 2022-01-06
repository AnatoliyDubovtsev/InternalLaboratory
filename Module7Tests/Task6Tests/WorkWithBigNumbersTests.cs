using Module7.Task6;
using NUnit.Framework;
using System;

namespace Module7Tests.Task6Tests
{
    public class WorkWithBigNumbersTests
    {
        [TestCase("1", null)]
        [TestCase(null, "1")]
        [TestCase("", "1")]
        [TestCase("1", "")]
        public void Sum_NullOrEmptyStringInput_ThrowsArgumentNullException(string left, string right)
            => Assert.Throws<ArgumentNullException>(() => WorkWithBigNumbers.Sum(left, right));

        [TestCase("100", "A", ExpectedResult = "The value could not be parsed.")]
        [TestCase("A", "100", ExpectedResult = "The value could not be parsed.")]
        public string Sum_NotANumberStringInput_ThrowsInvalidCastException(string left, string right)
            => WorkWithBigNumbers.Sum(left, right);

        [TestCase("9223372036854775807", "9223372036854775807", ExpectedResult = "18446744073709551614")] // long.MaxValue && long.MaxValue
        [TestCase("1", "1", ExpectedResult = "2")]
        public string Sum_CorrectStringInput_ReturnsResultString(string left, string right)
            => WorkWithBigNumbers.Sum(left, right);
    }
}
