using NUnit.Framework;

namespace Module2.NUnitTests
{
    public class IndexOfElementWithEqualSumOnBothSidesTests
    {
        [TestCase(new double[] { 1.5, 3.0, 1.5 }, ExpectedResult = 1)]
        [TestCase(new double[] { 1.0 }, ExpectedResult = 0)]
        [TestCase(new double[] { 1.11, 12.0, 11.9 }, ExpectedResult = -1)]
        [TestCase(new double[] { 1.1, 5.0, 6.0, 2.1, 4.0 }, ExpectedResult = 2)]
        [TestCase(new double[] { double.MaxValue / 2, 5.1, double.MaxValue, double.MinValue / 2}, ExpectedResult = 1)]
        [TestCase(new double[] { double.MinValue / 2, 5.1, double.MaxValue / 2, double.MinValue, 0}, ExpectedResult = 3)]
        [TestCase(new double[] { -1.1, 6.0, 6.0, 5.0, -0.1 }, ExpectedResult = 2)]
        [TestCase(new double[] {}, ExpectedResult = -1)]
        public int IndexOfElementWithEqualSumOnBothSides_ReturnsIndex(double[] arr)
            => Task3.IndexOfElementWithEqualSumOnBothSides(arr);
    }
}
