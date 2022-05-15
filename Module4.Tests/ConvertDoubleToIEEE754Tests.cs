using NUnit.Framework;

namespace Module4.Tests
{
    public class ConvertDoubleToIEEE754Tests
    {
        [TestCase(155.625, "0100000001100011011101000000000000000000000000000000000000000000")]
        [TestCase(-255.255, "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, "0111111111110000000000000000000000000000000000000000000000000000")]
        //[TestCase(-0.0, "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, "0000000000000000000000000000000000000000000000000000000000000000")]
        public void ConvertDoubleToIEEE754_ReturnsResult(double input, string expected)
        {
            var result = input.ConvertDoubleToIEEE754();
            Assert.AreEqual(expected, result);
        }
    }
}