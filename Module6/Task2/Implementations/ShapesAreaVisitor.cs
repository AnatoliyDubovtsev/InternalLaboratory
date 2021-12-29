using System;

namespace Module6.Task2.Implementations
{
    public class ShapesAreaVisitor : IVisitor
    {
        public double VisitCircle(double radius)
            => Math.PI * Math.Pow(radius, 2);

        public double VisitRectangle(double length, double width)
            => length * width;

        public double VisitSquare(double length)
            => Math.Pow(length, 2);

        public double VisitTriangle(double lengthOfBase, double height)
            => lengthOfBase * height / 2;
    }
}
