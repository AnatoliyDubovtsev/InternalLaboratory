using Common;
using System;

namespace Module3.Task2
{
    public class SortMatrix
    {
        private readonly ISortingStrategy _sortingStrategy;

        public SortMatrix(ISortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy;
        }

        public SortMatrix() { }

        public void Sorting(int[][] matrix)
        {
            Console.WriteLine("Types of sorting: ");
            foreach (var item in Enum.GetValues<SortingStrategies>())
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            Console.Write(Environment.NewLine + "Please, choose the type of sorting -> ");
            string choice = Console.ReadLine();
            int sortingType;
            if (!int.TryParse(choice, out sortingType))
            {
                throw new InvalidCastException("Entered data is not a number");
            }

            ISortingStrategy sortingStrategy = sortingType switch
            {
                (int)SortingStrategies.SortingByMaxElements => new SortingByMaxElements(),
                (int)SortingStrategies.SortingByMinElements => new SortingByMinElements(),
                (int)SortingStrategies.SortingBySum => new SortingBySum(),
                _ => throw new ArgumentException("Entered type not found")
            };

            bool isAscendingSorting = false;
            Console.Write("A - ascending sorting, D - descending sorting -> ");
            choice = Console.ReadLine().ToLower();
            if (choice != "a" && choice != "d")
            {
                throw new ArgumentException("Entered data is incorrect");
            }

            if (choice == "a")
            {
                isAscendingSorting = true;
            }

            Console.WriteLine("Matrix before sorting");
            CommonMethods.ShowMatrix(matrix);
            sortingStrategy.SortMatrix(matrix, isAscendingSorting);
            Console.WriteLine("Matrix after sorting");
            CommonMethods.ShowMatrix(matrix);
        }
    }
}
