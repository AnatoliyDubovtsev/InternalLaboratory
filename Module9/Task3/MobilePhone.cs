using System;

namespace Module9.Task3
{
    public class MobilePhone : Device, IObserver
    {
        public MobilePhone(string company, string model) : base(company, model) { }

        public void GetMessage(string message)
        {
            Console.WriteLine($"Message on mobile phone {Model}: {message}");
        }
    }
}
