using System;

namespace Module6.Task2.Implementations
{
    public class Rectangle : Shape
    {
        private double width;
        private double length;
        
        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width can not be less than zero");
                }

                width = value;
            }
        }

        public double Length
        {
            get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length can not be less than zero");
                }

                length = value;
            }
        }

        public Rectangle(string title, double length, double width) : base(title)
        {
            Length = length;
            Width = width;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitRectangle(Length, Width);
        
        public override double Perimeter(IVisitor visitor)
            => visitor.VisitRectangle(Length, Width);
    }
}
