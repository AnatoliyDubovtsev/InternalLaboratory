namespace Module6.Task2
{
    public abstract class Shape
    {
        public string Title { get; set; }

        protected Shape(string title)
        {
            Title = title;
        }

        public abstract double Area(IVisitor visitor);
        public abstract double Perimeter(IVisitor visitor);
    }
}
