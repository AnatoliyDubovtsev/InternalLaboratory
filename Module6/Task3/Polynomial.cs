using System;
using System.Text;

namespace Module6.Task3
{
    public class Polynomial
    {
        public int[] Coefficients { get; set; }

        public Polynomial(params int[] coefficients)
        {
            Coefficients = coefficients;
        }

        public Polynomial() { }

        public static int[] ConvertToArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            string[] coefficientsString = input.Split(' ');
            int[] array = new int[coefficientsString.Length];
            for (int i = 0; i < coefficientsString.Length; i++)
            {
                array[i] = int.Parse(coefficientsString[i]);
            }

            return array;
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (resultString.Length > 0 && Coefficients[i] >= 0)
                {
                    resultString.Append('+');
                }

                resultString.Append(Coefficients[i] + $"x^{i}");
            }

            return resultString.ToString();
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            int max = Math.Max(left.Coefficients.Length, right.Coefficients.Length);
            int[] resultArr = new int[max];
            for (int i = 0; i < max; i++)
            {
                if(left.Coefficients.Length <= i)
                {
                    resultArr[i] = right.Coefficients[i];
                }
                else if (right.Coefficients.Length <= i)
                {
                    resultArr[i] = left.Coefficients[i];
                }
                else
                {
                    resultArr[i] = left.Coefficients[i] + right.Coefficients[i];
                }
            }

            return new Polynomial(resultArr);
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            int max = Math.Max(left.Coefficients.Length, right.Coefficients.Length);
            int[] resultArr = new int[max];
            for (int i = 0; i < max; i++)
            {
                if (left.Coefficients.Length <= i)
                {
                    resultArr[i] = -right.Coefficients[i];
                }
                else if (right.Coefficients.Length <= i)
                {
                    resultArr[i] = left.Coefficients[i];
                }
                else
                {
                    resultArr[i] = left.Coefficients[i] - right.Coefficients[i];
                }
            }

            return new Polynomial(resultArr);
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            int max = left.Coefficients.Length + right.Coefficients.Length - 1;
            int[][] resultArr = new int[right.Coefficients.Length][];
            int shift = 0;
            for (int row = 0, rightIndex = 0; row < right.Coefficients.Length; row++, rightIndex++)
            {
                for (int col = 0, leftIndex = 0; col < max; col++)
                {
                    if (resultArr[row] == null)
                    {
                        resultArr[row] = new int[max];
                    }

                    if (leftIndex < left.Coefficients.Length && col >= shift)
                    {
                        resultArr[row][col] = left.Coefficients[leftIndex++] * right.Coefficients[rightIndex];
                    }
                    else if (leftIndex >= left.Coefficients.Length)
                    {
                        resultArr[row][col] = 0;
                    }
                }

                shift++;
            }

            Polynomial[] polynomials = new Polynomial[right.Coefficients.Length];
            for (int i = 0; i < right.Coefficients.Length; i++)
            {
                polynomials[i] = new Polynomial(resultArr[i]);
            }

            Polynomial resultPolynomial = new Polynomial(new int[max]);
            for (int i = 0; i < polynomials.Length; i++)
            {
                resultPolynomial += polynomials[i];
            }

            return resultPolynomial;
        }
    }
}
