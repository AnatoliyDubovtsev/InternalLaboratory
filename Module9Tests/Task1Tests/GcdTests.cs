using Module9.Task1;
using NUnit.Framework;
using System;
using System.IO;

namespace Module9Tests.Task1Tests
{
    public class GcdTests
    {
        [TestCase("2 4 8")]
        public void FindGcd_UsingDelegate_CorrectInput_ReturnsStringWithResults(string input)
        {
            //arrange
            using var reader = new StringReader(input);
            Console.SetIn(reader);

            //act
            var result = Gcd.FindGcd();

            //assert
            Assert.NotNull(result);
            Assert.AreNotEqual("", result);
        }

        [TestCase("")]
        public void FindGcd_UsingDelegate_EmptyString_ThrowsArgumentNullReferenceException(string input)
        {
            using var reader = new StringReader(input);
            Console.SetIn(reader);
            Assert.Throws<NullReferenceException>(() => Gcd.FindGcd());
        }
    }
}
