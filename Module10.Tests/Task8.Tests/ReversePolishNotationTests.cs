using Module10.Task8;
using NUnit.Framework;
using System;

namespace Module10.Tests.Task8.Tests
{
    public class ReversePolishNotationTests
    {
        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = 14)]
        [TestCase("1 2 +", ExpectedResult = 3)]
        [TestCase("120 10 25 4 * + - 2 * 2 /", ExpectedResult = 10)]
        [TestCase("1 2 3 * +", ExpectedResult = 7)]
        [TestCase("", ExpectedResult = 0)]
        public int Calculate_CorrectInput_ReturnsResult(string expression)
            => ReversePolishNotation.Calculate(expression);

        [TestCase("5 1 2+ 4 * + 3 -")]
        [TestCase("5 1 2 + 4 *+ 3 -")]
        [TestCase("5 1 2 +4 * + 3 -")]
        [TestCase("5 1 2 + 4* + 3 -")]
        [TestCase("5 1 2 + 4 * + 3-")]
        [TestCase("2 + 4 * + 3 -")]
        [TestCase("5 1 2 + 4 * + 3")]
        [TestCase("5 1 2 + 4 * 3 -")]
        [TestCase("1234 + 4 * + 3 -")]
        [TestCase("5 1 + 4 * 3")]
        [TestCase("5 1 + 4 * + 333")]
        [TestCase("5 1 + 4 * A 333")]
        public void Calculate_IncorrectNotNullInput_ThrowsArgumentException(string expression)
            => Assert.Throws<ArgumentException>(() => ReversePolishNotation.Calculate(expression));

        [TestCase("   ")]
        [TestCase(null)]
        public void Calculate_NullInput_ThrowsArgumentNullException(string expression)
            => Assert.Throws<ArgumentNullException>(() => ReversePolishNotation.Calculate(expression));
    }
}
