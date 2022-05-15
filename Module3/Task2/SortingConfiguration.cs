using Common;
using System;

namespace Module3.Task2
{
    public static class SortingConfiguration
    {
        public static void ChooseTypeOfSorting(out bool isAscendingSorting)
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

        public static ISortingStrategy ChooseSortingStrategy()
        {
            CollectionsCommonMethods.ShowCollectionItems(Enum.GetValues<SortingStrategies>());
            ISortingStrategy sortingStrategyMethod = null;
            do
            {
                Console.Write(Environment.NewLine + "Please, choose the sorting strategy -> ");
                string choice = Console.ReadLine();
                if (!int.TryParse(choice, out int sortingStrategy))
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

        public static ISortingStrategy GetSortingStrategy(int sortingStrategy)
            => sortingStrategy switch
            {
                (int)SortingStrategies.SortingByMaxElements => new SortingByMaxElements(),
                (int)SortingStrategies.SortingByMinElements => new SortingByMinElements(),
                (int)SortingStrategies.SortingBySum => new SortingBySum(),
                _ => null
            };
    }
}
