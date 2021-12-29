using System;

namespace Module6.Task2.Implementations
{
    public class Square : Shape
    {
        private double length;

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

        public Square(string title, double length) : base(title)
        {
            Length = length;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitSquare(Length);
    }
}
