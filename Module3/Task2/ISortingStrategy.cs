#pragma warning disable S2368
namespace Module3.Task2
{
    public interface ISortingStrategy
    {
        int[,] SortMatrix(int[,] matrix, bool isAscendingSorting);
    }
}