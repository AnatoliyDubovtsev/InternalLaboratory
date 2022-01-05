using Module7.Task5;
using NUnit.Framework;
using System;

namespace Module7Tests.Task5Tests
{
    public class WorkWithStringsTests
    {
        [TestCase("The greatest victory is that which requires no battle", ExpectedResult = "battle no requires which that is victory greatest The")]
        [TestCase("A bc d", ExpectedResult = "d bc A")]
        public string ReverseWords_CorrectStringInput_ReturnsResultString(string input)
            => WorkWithStrings.ReverseWords(input);

        [TestCase("")]
        [TestCase(null)]
        public void ReverseWords_IncorrectStringInput_ThrowsArgumentNullException(string input)
            => Assert.Throws<ArgumentNullException>(() => WorkWithStrings.ReverseWords(input));
    }
}
