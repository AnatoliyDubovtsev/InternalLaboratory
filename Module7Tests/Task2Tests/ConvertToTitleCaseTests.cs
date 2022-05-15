using Module7.Task2;
using NUnit.Framework;
using System;

namespace Module7Tests.Task2Tests
{
    public class ConvertToTitleCaseTests
    {
        [TestCase("a clash of KINGS", "a of", "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [TestCase("THE WIND IN THE WILLOWS", "The", "The Wind In the Willows")]
        [TestCase("   THE WIND IN THE WILLOWS   ", "  The   ", "The Wind In the Willows")]
        [TestCase("THE WIND IN THE WILLOWS", null, "The Wind In The Willows")]
        [TestCase("   THE WIND IN THE WILLOWS   ", null, "The Wind In The Willows")]
        [TestCase("the quick brown fox", null, "The Quick Brown Fox")]
        public void ConvertStringToTitleCase_ReturnsResult(string inputString, string minorWords, string expected)
        {
            var result = ConvertToTitleCase.ConvertStringToTitleCase(inputString, minorWords);
            Assert.AreEqual(expected, result);
        }

        [TestCase(null)]
        public void ConvertStringToTitleCase_NullInputString_ThrowsArgumentNullException(string inputString)
            => Assert.Throws<ArgumentNullException>(() => ConvertToTitleCase.ConvertStringToTitleCase(inputString));
    }
}
