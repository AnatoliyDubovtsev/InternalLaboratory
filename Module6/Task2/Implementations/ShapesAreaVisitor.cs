using System;

namespace Module6.Task2.Implementations
{
    public class ShapesAreaVisitor : IVisitor
    {
        public double VisitCircle(int radius)
            => 2 * Math.PI * radius;

        public double VisitRectangle(int length, int width)
            => length * width;

        public double VisitSquare(int length)
            => Math.Pow(length, 2);

        public double VisitTriangle(int lengthOfBase, int height)
            => lengthOfBase * height / 2;
    }
}
