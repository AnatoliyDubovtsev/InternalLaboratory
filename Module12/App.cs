using Module12.Implementation;
using Module12.Interfaces;
using System;

namespace Module12
{
    public class App
    {
        public void WorkWithReferentialType(Employee[] employees)
        {
            if (employees.Length <= 1)
            {
                return;
            }

            Console.WriteLine("Override ToString");
            string overrideString = employees[0].ToString();
            Console.ReadLine();

            Console.WriteLine("Base Equals");
            bool isEqual = employees[0].Equals(employees[1]);
            Console.ReadLine();

            Console.WriteLine("Explicit interface №1");
            IExplicit1 explicit1 = (IExplicit1)employees[0];
            explicit1.ShowMessage();
            Console.ReadLine();

            Console.WriteLine("Explicit interface №2");
            IExplicit2 explicit2 = (IExplicit2)employees[0];
            explicit2.ShowMessage();
            Console.ReadLine();

            Console.WriteLine("Implicit interface");
            IImplicit implicit1 = (IImplicit)employees[0];
            implicit1.ShowTime();
            Console.ReadLine();

            Console.WriteLine(employees.Length);
            Console.WriteLine(overrideString);
            Console.WriteLine(isEqual);
            Console.WriteLine(explicit1.GetType());
            Console.WriteLine(explicit2.GetType());
            Console.WriteLine(implicit1.GetType());
        }

        public void WorkWithValueType(Point2D[] points)
        {
            Console.WriteLine("Override string");
            string overrideString = points.ToString();
            Console.ReadLine();

            Console.WriteLine("Base Equals");
            bool isEqual = points[0].Equals(points[1]);
            Console.ReadLine();

            Console.WriteLine("Explicit interface №1");
            IExplicit1 explicit1 = (IExplicit1)points[0];
            explicit1.ShowMessage();
            Console.ReadLine();

            Console.WriteLine("Explicit interface №2");
            IExplicit2 explicit2 = (IExplicit2)points[0];
            explicit2.ShowMessage();
            Console.ReadLine();

            Console.WriteLine("Implicit interface");
            IImplicit implicit1 = (IImplicit)points[0];
            implicit1.ShowTime();
            Console.ReadLine();

            Console.WriteLine(points.Length);
            Console.WriteLine(overrideString);
            Console.WriteLine(isEqual);
            Console.WriteLine(explicit1.GetType());
            Console.WriteLine(explicit2.GetType());
            Console.WriteLine(implicit1.GetType());
        }
    }
}
