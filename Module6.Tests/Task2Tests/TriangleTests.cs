using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class TriangleTests
    {
        private IVisitor _areaVisitor;
        private readonly double _delta = 0.1;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
        }

        [TestCase(10, 5, 25)]
        [TestCase(5, 5, 12.5)]
        [TestCase(1, 1, 0.5)]
        [TestCase(0.5, 0.5, 0.125)]
        public void TriangleAreaTests_CorrectInput_ReturnsArea(double lengthOfBase, double height, double expected)
        {
            //arrange
            var triangle = new Triangle("", lengthOfBase, height);

            //act
            var result = triangle.Area(_areaVisitor);

            //assert
            Assert.AreEqual(expected, result, _delta);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void TriangleConstructor_IncorrectInput_ThrowsArgumentException(double lengthOfBase, double height)
            => Assert.Throws<ArgumentException>(() => new Triangle("", lengthOfBase, height));
    }
}
