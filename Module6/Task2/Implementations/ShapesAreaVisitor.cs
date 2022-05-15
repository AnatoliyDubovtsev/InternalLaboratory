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

        public double VisitTriangle(double side1, double side2, double side3)
        {
            double halfOfPerimeter = (side1 + side2 + side3) / 2;
            double middleResult = halfOfPerimeter * (halfOfPerimeter - side1) * (halfOfPerimeter - side2) * (halfOfPerimeter - side3);
            double area = Math.Sqrt(middleResult);
            return area;
        }
    }
}
