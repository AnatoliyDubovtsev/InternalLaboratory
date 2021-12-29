using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class SquareTests
    {
        private IVisitor _areaVisitor;
        private IVisitor _perimeterVisitor;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
            _perimeterVisitor = new ShapesPerimeterVisitor();
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
            Assert.AreEqual(expected, result);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void SquareAreaTests_IncorrectInput_ThrowArgumentException(double length)
            => Assert.Throws<ArgumentException>(() => new Square("", length));

        [TestCase(5, 20)]
        [TestCase(1.5, 6)]
        [TestCase(0.5, 2)]
        public void SquarePerimeterTests_CorrectInput_ReturnsPerimeter(double length, double expected)
        {
            //arrange
            var square = new Square("", length);

            //act
            var result = square.Perimeter(_perimeterVisitor);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
