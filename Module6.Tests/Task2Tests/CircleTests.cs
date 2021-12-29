using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class CircleTests
    {
        private IVisitor _areaVisitor;
        private IVisitor _perimeterVisitor;
        private readonly double _delta = 0.1;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
            _perimeterVisitor = new ShapesPerimeterVisitor();
        }

        [TestCase(10, 314.1)]
        [TestCase(5, 78.5)]
        public void CircleAreaTests_CorrectInput_ReturnsArea(double radius, double expected)
        {
            //arrange
            var circle = new Circle("", radius);

            //act
            var result = circle.Area(_areaVisitor);

            //assert
            Assert.AreEqual(expected, result, _delta);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CircleAreaTests_IncorrectInput_ThrowsArgumentException(double radius)
            => Assert.Throws<ArgumentException>(() => new Circle("", radius));

        [TestCase(5, 31.415)]
        [TestCase(10, 62.83)]
        [TestCase(1, 6.28)]
        public void CirclePerimeterTests_CorrectInput_ReturnsPerimeter(double radius, double expected)
        {
            //arrange
            var circle = new Circle("", radius);

            //act
            var result = circle.Perimeter(_perimeterVisitor);

            //assert
            Assert.AreEqual(expected, result, _delta);
        }
    }
}
