using System.Globalization;

namespace Module7.Task1
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name = "Default", string contactPhone = "Default", decimal revenue = 0)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public string CustomersInformation(CustomersInformationFormat format)
        {
            string result = "Customer record: ";
            result += format switch
            {
                CustomersInformationFormat.ContactPhone => ContactPhone,
                CustomersInformationFormat.FullInformation => $"{Name}, {Revenue.ToString("N", new CultureInfo("en-US"))}, {ContactPhone}",
                CustomersInformationFormat.Name => Name,
                CustomersInformationFormat.NameRevenue => $"{Name}, {Revenue.ToString("N", new CultureInfo("en-US"))}",
                CustomersInformationFormat.Revenue => Revenue.ToString("N", new CultureInfo("en-US")),
                _ => "Incorrect format"
            };

            return result;
        }
    }
}
