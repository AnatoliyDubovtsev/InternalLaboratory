using System;

namespace Module6.Task2.Implementations
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius can not be less than zero");
                }

                radius = value;
            }
        }

        public Circle(string title, double radius) : base(title)
        {
            Radius = radius;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitCircle(Radius);
    }
}
