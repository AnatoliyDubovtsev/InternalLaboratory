using System;

namespace Module6.Task2.Implementations
{
    public class Circle : Shape
    {
        private int radius;

        public int Radius
        {
            get => radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius can not be less than zero");
                }

                radius = value;
            }
        }

        public Circle(string title, int radius) : base(title)
        {
            Radius = radius;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitCircle(Radius);
    }
}
