using NUnit.Framework;
using System;

namespace Module3.Tests
{
    public class FindNthRootTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ReturnsResultNumber(double number, int degree, double precision, double expected)
            => Assert.AreEqual(expected, Task1.FindNthRoot(number, degree, precision), precision);

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        [TestCase(double.NaN, 2, 0.0001)]
        [TestCase(0.01, 2, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 2, 0.001)]
        [TestCase(0.01, 2, double.NegativeInfinity)]
        public void FindNthRoot_ThrowsArgumentException(double number, int degree, double precision)
            => Assert.Throws<ArgumentException>(() => Task1.FindNthRoot(number, degree, precision));
    }
}
