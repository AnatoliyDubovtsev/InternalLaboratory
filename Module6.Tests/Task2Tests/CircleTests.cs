using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class CircleTests
    {
        private IVisitor _areaVisitor;
        private readonly double _delta = 0.1;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
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
    }
}
