using System;

namespace Module6.Task2.Implementations
{
    public class ShapesPerimeterVisitor : IVisitor
    {
        public double VisitCircle(double radius)
            => 2 * Math.PI * radius;

        public double VisitRectangle(double length, double width)
            => 2 * length + 2 * width;

        public double VisitSquare(double length)
            => 4 * length;

        public double VisitTriangle(double side1, double side2, double side3)
            => side1 + side2 + side3;
    }
}
