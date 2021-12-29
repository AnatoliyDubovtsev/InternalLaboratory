using System;

namespace Module6.Task2.Implementations
{
    public class Triangle : Shape
    {
        private int lengthOfBase;
        private int height;

        public int LengthOfBase
        {
            get => lengthOfBase;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length of the base can not be less than zero");
                }

                lengthOfBase = value;
            }
        }

        public int Height
        {
            get => height;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height can not be less than zero");
                }

                height = value;
            }
        }

        public Triangle(string title, int lengthOfBase, int height) : base(title)
        {
            LengthOfBase = lengthOfBase;
            Height = height;
        }

        public override double Area(IVisitor visitor)
            => visitor.VisitTriangle(LengthOfBase, Height);
    }
}
