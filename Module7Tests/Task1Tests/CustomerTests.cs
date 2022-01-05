using Module7.Task1;
using NUnit.Framework;
using System.Globalization;
using System.Text;

namespace Module7Tests.Task1Tests
{
    public class CustomerTests
    {
        [TestCase(CustomersInformationFormat.FullInformation, "Jeffrey Richter", 1000000, "+1 (425) 555-0100")]
        [TestCase(CustomersInformationFormat.ContactPhone, null, -1, "+1 (425) 555-0100")]
        [TestCase(CustomersInformationFormat.Name, "Jeffrey Richter", -1, null)]
        [TestCase(CustomersInformationFormat.Revenue, null, 1000000, null)]
        [TestCase(CustomersInformationFormat.NameRevenue, "Jeffrey Richter", 1000000, null)]
        [TestCase((CustomersInformationFormat)10, null, -1, null)]
        public void CustomersInformation_ReturnsResultString(CustomersInformationFormat format, string name, decimal revenue, string contactPhone)
        {
            //arrange
            var customer = new Customer(name, contactPhone, revenue);
            StringBuilder expected = new StringBuilder("Customer record: ");
            int length = expected.Length;
            if (!string.IsNullOrEmpty(name))
            {
                expected.Append(name);
                if (revenue > 0 || !string.IsNullOrEmpty(contactPhone))
                {
                    expected.Append(", ");
                }
            }

            if (revenue >= 0)
            {
                expected.Append(revenue.ToString("N", new CultureInfo("en-US")));
                if (!string.IsNullOrEmpty(contactPhone))
                {
                    expected.Append(", ");
                }
            }

            if (!string.IsNullOrEmpty(contactPhone))
            {
                expected.Append(contactPhone);
            }

            if (length == expected.Length)
            {
                expected.Append("Incorrect format");
            }

            //act
            var result = customer.CustomersInformation(format);

            //assert
            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
