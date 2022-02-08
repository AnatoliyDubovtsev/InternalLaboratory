using Module11.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module11
{
    public class Task1
    {
        private const string _path = @"..\..\..\..\Module11\Results.txt";

        public Task1()
        {
            InitializeFile();
        }

        public IEnumerable<TestResults> GetAllTestResults()
            => CombineIntoResponse(ReadingFileApproach.ReadAllData);

        public IEnumerable<TestResults> GetTestResultsByQuantity(int quantity)
            => CombineIntoResponse(ReadingFileApproach.ReadExactQuantity, quantity);

        public IEnumerable<TestResults> ResultsFilteredByAssessmentValue(IEnumerable<TestResults> testResults, int assessmentValue, bool isMoreThanValue)
        {
            if (testResults == null)
            {
                throw new ArgumentNullException(nameof(testResults), $"{nameof(testResults)} argument is a null");
            }

            testResults = isMoreThanValue ? testResults.Where(x => x.Assessment >= assessmentValue) : testResults.Where(x => x.Assessment <= assessmentValue);
            testResults = testResults.OrderBy(x => x.Assessment).Select(x => x);
            return testResults;
        }

        public IEnumerable<TestResults> SortTestResults(IEnumerable<TestResults> testResults, SortingTypes sortingType, bool isAscending)
        {
            testResults = sortingType switch
            {
                SortingTypes.ByStudentName => from tr in testResults orderby tr.StudentName select tr,
                SortingTypes.ByTestName => from tr in testResults orderby tr.TestName select tr,
                SortingTypes.ByDate => from tr in testResults orderby tr.Date select tr,
                _ => from tr in testResults orderby tr.Assessment select tr
            };

            if (!isAscending)
            {
                testResults = testResults.Reverse();
            }

            return testResults;
        }

        private IEnumerable<TestResults> CombineIntoResponse(ReadingFileApproach readingFileApproach, int quantity = 0)
        {
            IEnumerable<TestResults> testResults = Array.Empty<TestResults>().AsEnumerable<TestResults>();
            foreach (var item in GetTestResults(quantity, readingFileApproach))
            {
                testResults = testResults.Append<TestResults>(item);
            }

            return testResults;
        }

        private IEnumerable<TestResults> GetTestResults(int quantity, ReadingFileApproach readingFileApproach)
        {
            int counter = 0;
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream))
                {
                    Func<bool> predicate;
                    if (readingFileApproach == ReadingFileApproach.ReadAllData)
                    {
                        predicate = () => reader.PeekChar() != -1;
                    }
                    else
                    {
                        predicate = () => reader.PeekChar() != -1 && counter < quantity;
                    }

                    while (predicate.Invoke())
                    {
                        counter++;
                        yield return new TestResults
                        {
                            StudentName = reader.ReadString(),
                            TestName = reader.ReadString(),
                            Date = DateTime.Parse(reader.ReadString()),
                            Assessment = reader.ReadInt32()
                        };
                    }
                }
            }
        }

        private void InitializeFile()
        {
            bool isEmpty;
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream))
                {
                    isEmpty = reader.PeekChar() == -1;                    
                }
            }

            if (!isEmpty)
            {
                return;
            }

            Data data = new();
            int studentsCount = data.StudentsNames.Count;
            int testsCount = data.TestsNames.Count;
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    for (int studentId = 0, testId = 0; studentId < studentsCount; studentId++, testId++)
                    {
                        writer.Write(data.StudentsNames[studentId]);
                        testId = testId == testsCount ? 0 : testId;
                        writer.Write(data.TestsNames[testId]);
                        writer.Write(data.Dates[testId].ToShortDateString());
                        writer.Write(data.Assessments[studentId]);
                    }
                }
            }
        }
    }
}
