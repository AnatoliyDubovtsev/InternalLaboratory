namespace Module6.Task2
{
    public interface IVisitor
    {
        double VisitCircle(double radius);
        double VisitTriangle(double lengthOfBase, double height);
        double VisitSquare(double length);
        double VisitRectangle(double length, double width);
    }
}
