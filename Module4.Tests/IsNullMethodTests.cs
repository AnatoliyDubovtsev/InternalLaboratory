using NUnit.Framework;

namespace Module4.Tests
{
    public class IsNullMethodTests
    {
        [TestCase("string", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public bool IsNull_InputString_ReturnsBoolean(string input)
            => input.IsNull();

        [Test]
        public void IsNull_InputNullableStruct_ReturnsBoolean()
        {
            int? notNullInt = 5;
            int? nullInt = null;
            double? notNullDouble = 10.11;
            double? nullDouble = null;

            Assert.True(nullInt.IsNull());
            Assert.True(nullDouble.IsNull());
            Assert.False(notNullInt.IsNull());
            Assert.False(notNullDouble.IsNull());
        }
    }
}
