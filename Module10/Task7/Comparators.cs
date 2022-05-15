using Module10.Task7.Objects;
using System;
using System.Collections.Generic;

namespace Module10.Task7
{
    public class Comparators<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "Left item is a null");
            }
            else if (y == null)
            {
                throw new ArgumentNullException(nameof(y), "Right item is a null");
            }
            else if (x is string leftStr && y is string rightStr)
            {
                return CompareStrings(leftStr, rightStr);
            }
            else if (x is Book leftBook && y is Book rightBook)
            {
                return CompareBooks(leftBook, rightBook);
            }
            else if (x is Point leftPoint && y is Point rightPoint)
            {
                return ComparePoints(leftPoint, rightPoint);
            }
            else
            {
                return x.ToString().CompareTo(y.ToString());
            }
        }

        private int ComparePoints(Point left, Point right)
        {
            double leftPointHypotenuse = Hypotenuse(left);
            double rightPointHypotenuse = Hypotenuse(right);
            int result = leftPointHypotenuse.CompareTo(rightPointHypotenuse);
            if (result == 0)
            {
                result = left.X.CompareTo(right.X);
            }

            return result;
        }

        private double Hypotenuse(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
        }

        private int CompareBooks(Book left, Book right)
        {
            return left.Year.CompareTo(right.Year);
        }

        private int CompareStrings(string left, string right)
        {
            if (left.Length == 0 && right.Length == 0)
            {
                return 0;
            }
            else if (left.Length == 0)
            {
                return -1;
            }
            else if (right.Length == 0)
            {
                return 1;
            }

            int result = left[0].CompareTo(right[0]);
            if (result == 0)
            {
                result = left.Length.CompareTo(right.Length);
            }

            return result;
        }
    }
}
