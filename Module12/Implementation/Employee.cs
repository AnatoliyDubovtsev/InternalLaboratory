using Module12.Interfaces;
using System;

namespace Module12.Implementation
{
    public class Employee : IImplicit, IExplicit1, IExplicit2
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public Employee(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Employee() : this("", "") { }

        public override string ToString() => $"Name: {Name} Surname: {Surname}";

        public string BaseToString() => base.ToString();

        public void ShowTime() => Console.WriteLine("Today: " + DateTime.Now);

        void IExplicit1.ShowMessage() => Console.WriteLine("Explicit1.ShowMessage() from Employee");

        void IExplicit2.ShowMessage() => Console.WriteLine("Explicit2.ShowMessage() from Employee");

        ~Employee()
        {
            Console.WriteLine("In destructor");
        }
    }
}
