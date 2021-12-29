using Module6.Task2;
using Module6.Task2.Implementations;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task2Tests
{
    public class RectangleTests
    {
        private IVisitor _areaVisitor;

        [SetUp]
        public void Setup()
        {
            _areaVisitor = new ShapesAreaVisitor();
        }

        [TestCase(10, 5, 50)]
        [TestCase(5, 5, 25)]
        public void RectangleAreaTest_CorrectInput_ReturnsArea(double length, double width, double expected)
        {
            //arrange
            var rectangle = new Rectangle("", length, width);

            //act
            var result = rectangle.Area(_areaVisitor);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [TestCase(-1, 5)]
        [TestCase(5, -1)]
        public void RectangleConstructor_IncorrectInput_ThrowsArgumentException(double length, double width)
            => Assert.Throws<ArgumentException>(() => new Rectangle("", length, width));
    }
}
