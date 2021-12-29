using System;

namespace Module6.Task2.Implementations
{
    public class Triangle : Shape
    {
        private double lengthOfBase;
        private double height;

        public double LengthOfBase
        {
            get => lengthOfBase;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length of the base can not be less than zero");
                }

                lengthOfBase = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height can not be less than zero");
                }

                height = value;
            }
        }

        public Triangle(string title, double lengthOfBase, double height) : base(title)
        {
            LengthOfBase = lengthOfBase;
            Height = height;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitTriangle(LengthOfBase, Height);
    }
}
