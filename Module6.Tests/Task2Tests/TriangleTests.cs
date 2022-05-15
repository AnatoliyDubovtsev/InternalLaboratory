using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class TriangleTests
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

        [TestCase(10, 5, 10, 24.2)]
        [TestCase(5, 5, 5, 10.8)]
        [TestCase(3.2, 2.5, 2.7, 3.27)]
        public void TriangleAreaTests_CorrectInput_ReturnsArea(double side1, double side2, double side3, double expected)
        {
            //arrange
            var triangle = new Triangle("", side1, side2, side3);

            //act
            var result = triangle.Area(_areaVisitor);

            //assert
            Assert.AreEqual(expected, result, _delta);
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void TriangleConstructor_IncorrectInput_ThrowsArgumentException(double side1, double side2, double side3)
            => Assert.Throws<ArgumentException>(() => new Triangle("", side1, side2, side3));

        [TestCase(3, 4, 5, 12)]
        [TestCase(3, 3, 3, 9)]
        [TestCase(0.5, 0.75, 1, 2.25)]
        public void TrianglePerimeterTests_CorrectInput_ReturnsPerimeter(double side1, double side2, double side3, double expected)
        {
            //arrange
            var triangle = new Triangle("", side1, side2, side3);

            //act
            var result = triangle.Perimeter(_perimeterVisitor);

            //assert
            Assert.AreEqual(expected, result, _delta);
        }
    }
}
