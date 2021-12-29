using System;

namespace Module6.Task2.Implementations
{
    public class Rectangle : Shape
    {
        private int width;
        private int length;
        
        public int Width
        {
            get => width;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width can not be less than zero");
                }

                width = value;
            }
        }

        public int Length
        {
            get => length;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length can not be less than zero");
                }

                length = value;
            }
        }

        public Rectangle(string title, int length, int width) : base(title)
        {
            Length = length;
            Width = width;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitRectangle(Length, Width);
    }
}
