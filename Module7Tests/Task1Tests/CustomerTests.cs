using Module7.Task1;
using NUnit.Framework;

namespace Module7Tests.Task1Tests
{
    public class CustomerTests
    {
        [TestCase(CustomersInformationFormat.FullInformation, "Customer record: Jeffrey Richter, 1,000,000.000, +1 (425) 555-0100")]
        [TestCase(CustomersInformationFormat.ContactPhone, "Customer record: +1 (425) 555-0100")]
        [TestCase(CustomersInformationFormat.Name, "Customer record: Jeffrey Richter")]
        [TestCase(CustomersInformationFormat.Revenue, "Customer record: 1,000,000.000")]
        [TestCase(CustomersInformationFormat.NameRevenue, "Customer record: Jeffrey Richter, 1,000,000.000")]
        [TestCase((CustomersInformationFormat)10, "Customer record: Incorrect format")]
        public void CustomersInformation_ReturnsResultString(CustomersInformationFormat format, string expected)
        {
            //arrange
            var customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000.00M);

            //act
            var result = customer.CustomersInformation(format);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
