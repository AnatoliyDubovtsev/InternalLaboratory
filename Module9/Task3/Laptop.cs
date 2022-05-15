using System;

namespace Module9.Task3
{
    public class Laptop : Device, IObserver
    {
        public Laptop(string company, string model) : base(company, model) { }

        public void GetMessage(string message)
        {
            Console.WriteLine($"Message on laptop {Model}: {message}");
        }
    }
}
