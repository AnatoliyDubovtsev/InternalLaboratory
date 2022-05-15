using Module12.Interfaces;
using System;

namespace Module12.Implementation
{
    public struct Point2D : IImplicit, IExplicit1, IExplicit2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X};{Y})";

        public string BaseToString() => base.ToString();

        public void ShowTime() => Console.WriteLine("Today: " + DateTime.Now);

        void IExplicit1.ShowMessage() => Console.WriteLine("IExplicit1.ShowMessage() from Point2D");

        void IExplicit2.ShowMessage() => Console.WriteLine("IExplicit2.ShowMessage() from Point2D");
    }
}
