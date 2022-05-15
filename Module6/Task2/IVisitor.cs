namespace Module6.Task2
{
    public interface IVisitor
    {
        double VisitCircle(double radius);
        double VisitTriangle(double side1, double side2, double side3);
        double VisitSquare(double length);
        double VisitRectangle(double length, double width);
    }
}
