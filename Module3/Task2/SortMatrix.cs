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

        public void Sorting(int[,] matrix)
        {
            CommonMethods.ShowCollectionItems(Enum.GetValues<SortingStrategies>());
            ISortingStrategy sortingStrategy = ChooseSortingStrategy();
            ChooseTypeOfSorting(out bool isAscendingSorting);
            Console.WriteLine("Matrix before sorting");
            CommonMethods.ShowMatrix<int>(matrix);
            sortingStrategy.SortMatrix(matrix, isAscendingSorting);
            Console.WriteLine("Matrix after sorting");
            CommonMethods.ShowMatrix<int>(matrix);
        }

        public ISortingStrategy ChooseSortingStrategy()
        {
            int sortingStrategy;
            ISortingStrategy sortingStrategyMethod = null;
            do
            {
                Console.Write(Environment.NewLine + "Please, choose the sorting strategy -> ");
                string choice = Console.ReadLine();
                if (!int.TryParse(choice, out sortingStrategy))
                {
                    Console.WriteLine("Entered data is not a number. Please, try again");
                    continue;
                }

                sortingStrategyMethod = GetSortingStrategy(sortingStrategy);
                if (sortingStrategyMethod == null)
                {
                    Console.WriteLine("Sorting strategy is not found. Please, try again");
                }
            } while (sortingStrategyMethod == null);

            return sortingStrategyMethod;
        }

        public void ChooseTypeOfSorting(out bool isAscendingSorting)
        {
            bool isCorrect;
            string choice;
            do
            {
                Console.Write("A - ascending sorting, D - descending sorting -> ");
                choice = Console.ReadLine().ToLower();
                isCorrect = choice == "a" || choice == "d";
                if (!isCorrect)
                {
                    Console.WriteLine("Entered data is incorrect. Please, try again");
                }
            } while (!isCorrect);

            isAscendingSorting = choice == "a";
        }

        public ISortingStrategy GetSortingStrategy(int sortingStrategy)
            => sortingStrategy switch
            {
                (int)SortingStrategies.SortingByMaxElements => new SortingByMaxElements(),
                (int)SortingStrategies.SortingByMinElements => new SortingByMinElements(),
                (int)SortingStrategies.SortingBySum => new SortingBySum(),
                _ => null
            };
    }
}