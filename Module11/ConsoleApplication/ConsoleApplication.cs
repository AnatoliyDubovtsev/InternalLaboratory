using Module11.Enums;
using Module11.Implementation;
using Module11.InformationExtraction;
using System;
using System.Collections.Generic;

namespace Module11.ConsoleApplication
{
    public class ConsoleApplication
    {
        public void App()
        {
            Task1 task1 = new Task1();
            task1.InitializeFile();
            bool repeat = true;
            while (repeat)
            {
                IEnumerable<TestResults> results = ReadingFile(task1);
                results = SortingResults(results, task1);
                results = FilteringResults(results, task1);
                Extraction(results, task1);

                Console.WriteLine("Try again? (y/n)");
                string answer = Console.ReadLine().ToLower();
                repeat = answer == "y";
                Console.WriteLine(Environment.NewLine + "---------------------------------------------------" + Environment.NewLine);
            }

        }

        private IEnumerable<TestResults> ReadingFile(Task1 task1)
        {
            Console.WriteLine($"1 - read all test results{Environment.NewLine}2 - read necessary quantity of test results");
            string answer = Console.ReadLine();
            int quantity;
            IEnumerable<TestResults> results = null;
            if (answer == "1")
            {
                results = task1.GetAllTestResults();
            }
            else if (answer == "2")
            {
                Console.Write("Enter necessary quantity: ");
                quantity = int.Parse(Console.ReadLine());
                results = task1.GetTestResultsByQuantity(quantity);
            }
            else
            {
                Console.WriteLine("Incorrect input. Please, try again");
                return null;
            }

            Console.WriteLine($"1 - Show test results{Environment.NewLine}2 - Continue");
            answer = Console.ReadLine();
            if (answer == "1")
            {
                Common.CollectionsCommonMethods.ShowCollectionItems<TestResults>(results);
                Console.WriteLine();
            }

            return results;
        }

        private IEnumerable<TestResults> SortingResults(IEnumerable<TestResults> results, Task1 task1)
        {
            Console.WriteLine($"1 - Sort by student names{Environment.NewLine}" +
                    $"2 - Sort by test titles{Environment.NewLine}" +
                    $"3 - Sort by dates{Environment.NewLine}" +
                    $"4 - Sort by assessments{Environment.NewLine}" +
                    $"5 - Continue");
            int sortingType = int.Parse(Console.ReadLine());
            if (sortingType >= 1 && sortingType <= 4)
            {
                Console.Write("Is ascending? (y/n): ");
                bool isAscending = Console.ReadLine().ToLower() == "y";
                results = sortingType switch
                {
                    1 => task1.SortTestResults(results, SortingTypes.ByStudentName, isAscending),
                    2 => task1.SortTestResults(results, SortingTypes.ByTestTitle, isAscending),
                    3 => task1.SortTestResults(results, SortingTypes.ByDate, isAscending),
                    _ => task1.SortTestResults(results, SortingTypes.ByAssessment, isAscending)
                };

                Console.WriteLine($"1 - Show sorted data{Environment.NewLine}" +
                    $"2 - Continue");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Common.CollectionsCommonMethods.ShowCollectionItems<TestResults>(results);
                    Console.WriteLine();
                }
            }

            return results;
        }

        private IEnumerable<TestResults> FilteringResults(IEnumerable<TestResults> results, Task1 task1)
        {
            Console.WriteLine($"1 - Take test results with assessments more than or equal to input value{Environment.NewLine}" +
                    $"2 - Take test results with assessments less than or equal to input value{Environment.NewLine}" +
                    $"3 - Continue");
            string answer = Console.ReadLine();
            if (answer == "1" || answer == "2")
            {
                bool isMore = answer == "1";
                Console.Write("Quantity: ");
                int assessment = int.Parse(Console.ReadLine());
                results = task1.ResultsFilteredByAssessmentValue<TestResults>(results, assessment, isMore);
                Console.WriteLine($"1 - Show filtered data{Environment.NewLine}" +
                    $"2 - Continue");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Common.CollectionsCommonMethods.ShowCollectionItems<TestResults>(results);
                    Console.WriteLine();
                }
            }

            return results;
        }

        private void Extraction(IEnumerable<TestResults> results, Task1 task1)
        {
            Console.WriteLine($"1 - Extract student names from collection{Environment.NewLine}" +
                    $"2 - Extract student names and assessments from collection{Environment.NewLine}" +
                    $"3 - Extract student names, assessments and test titles from collection{Environment.NewLine}" +
                    $"4 - Extract student names, assessments and dates from collection{Environment.NewLine}" +
                    $"5 - Extract test titles and dates from collection{Environment.NewLine}" +
                    $"6 - Continue");
            int extractionType = int.Parse(Console.ReadLine());
            IEnumerable<string> extractedString = null;
            IEnumerable<TestResultsStudentNameAssessment> extractedStudentData = null;
            IEnumerable<TestResultsTestTitleDate> extractedTestData = null;
            if (extractionType == 1)
            {
                extractedString = task1.ExtractStudentNamesFromCollection(results);
            }
            else if (extractionType == 5)
            {
                extractedTestData = task1.ExtractTestTitleAndDateFromCollection(results);
            }

            extractedStudentData = extractionType switch
            {
                2 => task1.ExtractStudentNamesAndAssessmentsFromCollection(results),
                3 => task1.ExtractStudentNamesAssessmentsAndTestTitlesFromCollection(results),
                4 => task1.ExtractStudentNamesAssessmentsAndDatesFromCollection(results),
                _ => null
            };

            if (extractionType >= 1 && extractionType <= 5)
            {
                Console.WriteLine($"1 - Show extracted results{Environment.NewLine}2 - Continue");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    switch (extractionType)
                    {
                        case 1: Common.CollectionsCommonMethods.ShowCollectionItems<string>(extractedString); break;
                        case 5: Common.CollectionsCommonMethods.ShowCollectionItems<TestResultsTestTitleDate>(extractedTestData); break;
                        default: Common.CollectionsCommonMethods.ShowCollectionItems<TestResultsStudentNameAssessment>(extractedStudentData); break;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
