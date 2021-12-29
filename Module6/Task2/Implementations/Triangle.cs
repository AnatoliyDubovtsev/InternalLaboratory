using System;

namespace Module6.Task2.Implementations
{
    public class Triangle : Shape
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public double Side1
        {
            get => _side1;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length of the side can not be less than zero");
                }

                _side1 = value;
            }
        }

        public double Side2
        {
            get => _side2;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length of the side can not be less than zero");
                }

                _side2 = value;
            }
        }

        public double Side3
        {
            get => _side3;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length of the side can not be less than zero");
                }

                _side3 = value;
            }
        }

        public Triangle(string title, double side1, double side2, double side3) : base(title)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitTriangle(Side1, Side2, Side3);

        public override double Perimeter(IVisitor visitor)
            => visitor.VisitTriangle(Side1, Side2, Side3);
    }
}
