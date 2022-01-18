using NUnit.Framework;
using System;

namespace Module2.NUnitTests
{
    public class StringConcatenationTests
    {
        [TestCase("AbcdAbef", "AefRg", ExpectedResult = "AbcdefRg")]
        [TestCase("AaAAAa", "AaAa", ExpectedResult = "Aa")]
        [TestCase("aabbddxxyyzz", "AABBBDDDXXXYYYZZZ", ExpectedResult = "abdxyzABDXYZ")]
        public string StringConcatenation_ReturnsResultString(string leftString, string rightString)
            => Task4.StringsConcatenation(leftString, rightString);

        [TestCase("", "Abcd")]
        [TestCase("a", "")]
        [TestCase(null, "Abs")]
        [TestCase("abs", null)]
        public void StringConcatenation_ThrowArgumentNullException(string leftString, string rightString)
            => Assert.Throws<ArgumentNullException>(() => Task4.StringsConcatenation(leftString, rightString));

        [TestCase("Abc", "AbД")]
        [TestCase("AbД", "Abc")]
        [TestCase("+", "b")]
        [TestCase("b", "-")]
        public void StringConcantenation_ThrowsArgumentException(string leftString, string rightString)
            => Assert.Throws<ArgumentException>(() => Task4.StringsConcatenation(leftString, rightString));
    }
}
