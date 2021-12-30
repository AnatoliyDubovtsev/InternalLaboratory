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

        public override bool Equals(object obj)
        {
            Polynomial polynomial = obj as Polynomial;
            if (polynomial == null)
            {
                throw new InvalidCastException("Invalid type");
            }
            else if (polynomial.Coefficients.Length != this.Coefficients.Length)
            {
                return false;
            }
            
            for (int i = 0; i < this.Coefficients.Length; i++)
            {
                if (this.Coefficients[i] != polynomial.Coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
            => this.ToString().GetHashCode();

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
                }

                shift++;
            }

            Polynomial resultPolynomial = new Polynomial(new int[max]);
            for (int i = 0; i < resultArr.Length; i++)
            {
                resultPolynomial += new Polynomial(resultArr[i]);
            }

            return resultPolynomial;
        }
    }
}
