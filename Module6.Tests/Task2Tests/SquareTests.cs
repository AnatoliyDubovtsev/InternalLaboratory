using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class SquareTests
    {
        private IVisitor _areaVisitor;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
        }

        [TestCase(10, 100)]
        [TestCase(2, 4)]
        [TestCase(1, 1)]
        public void SquareAreaTests_CorrectInput_ReturnsArea(double length, double expected)
        {
            //arrange
            var square = new Square("", length);

            //act
            var result = square.Area(_areaVisitor);

            //assert
            Assert.AreEqual(result, expected);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void SquareAreaTests_IncorrectInput_ThrowArgumentException(double length)
            => Assert.Throws<ArgumentException>(() => new Square("", length));
    }
}
