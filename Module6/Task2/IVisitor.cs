namespace Module6.Task2
{
    public interface IVisitor
    {
        double VisitCircle(int radius);
        double VisitTriangle(int lengthOfBase, int height);
        double VisitSquare(int length);
        double VisitRectangle(int length, int width);
    }
}
