﻿using NUnit.Framework;
using System;

namespace Module2.NUnitTests
{
    public class StringConcatenationTests
    {
        [TestCase("AbcdAbef", "AefRg", ExpectedResult = "AbcdefRg")]
        [TestCase("AaAAAa", "AaAa", ExpectedResult = "Aa")]
        [TestCase("123", "123123", ExpectedResult = "123")]
        [TestCase("123456789123456789123456789123456789123456789123456789123456789123456789", "123456789123456789123456789123456789", ExpectedResult = "123456789")]
        public string StringConcatenation_ReturnsResultString(string leftString, string rightString)
            => Task4.StringsConcatenation(leftString, rightString);

        [TestCase("", "Abcd")]
        [TestCase("a", "")]
        [TestCase(null, "Abs")]
        [TestCase("abs", null)]
        public void StringConcatenation_ThrowArgumentNullException(string leftString, string rightString)
            => Assert.Throws<ArgumentNullException>(() => Task4.StringsConcatenation(leftString, rightString));
    }
}
