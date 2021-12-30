﻿using Module6.Task3;
using NUnit.Framework;
using System;

namespace Module6.Tests.Task3Tests
{
    public class PolynomialTests
    {
        #region ConvertToArrayTests
        [TestCase("0 1 2 3 4 5", ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase("1", ExpectedResult = new int[] { 1 })]
        public int[] Polynomial_ConvertToArray_CorrectInput_ReturnIntArray(string input)
            => Polynomial.ConvertToArray(input);

        [TestCase(null)]
        public void Polynomial_ConvertToArray_NullInput_ThrowsArgumentNullException(string input)
            => Assert.Throws<ArgumentNullException>(() => Polynomial.ConvertToArray(input));

        [TestCase("A")]
        [TestCase("0.8")]
        public void Polynomial_ConvertToArray_IncorrectFormat_ThrowsFormatException(string input)
            => Assert.Throws<FormatException>(() => Polynomial.ConvertToArray(input));

        [TestCase("-20000000000")]
        [TestCase("20000000000")]
        public void Polynomial_ConvertToArray_InputOutOfIntBorders_ThrowsOverflowException(string input)
            => Assert.Throws<OverflowException>(() => Polynomial.ConvertToArray(input));
        #endregion

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, new int[] { 1, 3, 5, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 1, -1, 5, -6 }, new int[] { 2, -1, 5, -6 })]
        [TestCase(new int[] { -1, -5, 6, 2 }, new int[] { 3, 5, -2, 2 }, new int[] { 2, 0, 4, 4 })]
        public void Polynomial_OperatorPlus_ReturnPolynomial(int[] leftArray, int[] rightArray, int[] expected)
        {
            //arrange
            var left = new Polynomial(leftArray);
            var right = new Polynomial(rightArray);

            //act
            var result = left + right;

            //assert
            CollectionAssert.AreEqual(expected, result.Coefficients);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { -1, 2, -5 }, new int[] { 1, -1, 7, 3, 4 })]
        [TestCase(new int[] { -1, 2, -5 }, new int[] { 0, 1, 2, 3, 4 }, new int[] { -1, 1, -7, -3, -4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 }, new int[] { 0, 2 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 2 }, new int[] { 0, -2 })]
        public void Polynomial_OperatorMinus_ReturnPolynomial(int[] leftArray, int[] rightArray, int[] expected)
        {
            //arrange
            var left = new Polynomial(leftArray);
            var right = new Polynomial(rightArray);

            //act
            var result = left - right;

            //assert
            CollectionAssert.AreEqual(expected, result.Coefficients);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 1, 2, 3 }, new int[] { 3, 7, 13, 22, 16, 17, 12 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1 }, new int[] { 1, 2, 3 })]
        public void Polynomial_OperatorMult_ReturnPolynomial(int[] leftArray, int[] rightArray, int[] expected)
        {
            //arrange
            var left = new Polynomial(leftArray);
            var right = new Polynomial(rightArray);

            //act
            var result = left * right;

            //assert
            CollectionAssert.AreEqual(expected, result.Coefficients);
        }
    }
}
