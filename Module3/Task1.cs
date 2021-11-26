using System;

namespace Module3
{
    public static class Task1
    {
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Number cannot be less than zero", nameof(number));
            }
            else if (degree < 0)
            {
                throw new ArgumentException("Degree cannot be less than zero", nameof(degree));
            }
            else if (precision <= 0)
            {
                throw new ArgumentException("Precision cannot be less than or equal to zero", nameof(precision));
            }
            else if (double.IsNaN(number) || double.IsInfinity(number))
            {
                throw new ArgumentException($"Number's value ({number}) is incorrect", nameof(number));
            }
            else if (double.IsNaN(precision) || double.IsInfinity(precision))
            {
                throw new ArgumentException($"Precision's value ({precision}) is incorrect", nameof(precision));
            }

            double x_k = number, x_0;
            do
            {
                x_0 = x_k;
                x_k = (1.0 / degree) * (((degree - 1.0) * x_0) + (number / Math.Pow(x_0, degree - 1)));
            }
            while (Math.Abs(x_k - x_0) > precision);

            return x_k;

        }
    }
}
