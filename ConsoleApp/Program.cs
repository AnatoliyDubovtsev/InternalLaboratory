using Module3.Task2;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Module 2, Task 5
            /*Console.Write("Enter the number -> ");
            int number = int.Parse(Console.ReadLine());
            int newNumber = Task5.FindNextBiggerNumber(number, out double elapsedMilliseconds);
            Console.WriteLine($"New number: {newNumber}, Elapsed time: {elapsedMilliseconds} ms");*/

            // Module 3, Task 2
            int[,] matrix = new int[,]
            {
                { 1, 2, 3 },
                { 3, 4, 5 },
                { 4, 0, 6 }
            };

            ISortingStrategy sortingStrategy = SortingConfiguration.ChooseSortingStrategy();
            SortMatrix sortMatrix = new(sortingStrategy);
            SortingConfiguration.ChooseTypeOfSorting(out bool isAscendingSorting);
            sortMatrix.Sorting(matrix, isAscendingSorting); 
        }
    }
}