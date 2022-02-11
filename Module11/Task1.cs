using Module11.Enums;
using Module11.InformationExtraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module11
{
    public class Task1
    {
        private readonly string _path;
        private const string _defaultPath = @"..\..\..\..\Module11\Results.txt";
        private readonly Data _data;

        public Task1(string path, Data data)
        {
            _path = path;
            _data = data;
        }

        public Task1() : this(_defaultPath, new Data()) { }

        #region InformationExtraction
        public IEnumerable<TestResultsStudentName> ExtractStudentNamesFromCollection(IEnumerable<TestResults> testResults)
            => from x in testResults
               select new TestResultsStudentName
               {
                   StudentName = x.StudentName
               };

        public IEnumerable<TestResultsStudentNameAssessment> ExtractStudentNamesAndAssessmentsFromCollection(IEnumerable<TestResults> testResults)
            => from x in testResults
               select new TestResultsStudentNameAssessment
               {
                   StudentName = x.StudentName,
                   Assessment = x.Assessment
               };

        public IEnumerable<TestResultsStudentNameTestTitleAssessment> ExtractStudentNamesAssessmentsAndTestTitlesFromCollection(IEnumerable<TestResults> testResults)
            => from x in testResults
               select new TestResultsStudentNameTestTitleAssessment
               {
                   StudentName = x.StudentName,
                   Assessment = x.Assessment,
                   TestTitle = x.TestTitle
               };

        public IEnumerable<TestResultsStudentNameAssessmentDate> ExtractStudentNamesAssessmentsAndDatesFromCollection(IEnumerable<TestResults> testResults)
            => from x in testResults
               select new TestResultsStudentNameAssessmentDate
               {
                   StudentName = x.StudentName,
                   Assessment = x.Assessment,
                   Date = x.Date
               };

        public IEnumerable<TestResultsTestTitleDate> ExtractTestTitleAndDateFromCollection(IEnumerable<TestResults> testResults)
            => from x in testResults
               select new TestResultsTestTitleDate
               {
                   TestTitle = x.TestTitle,
                   Date = x.Date
               };
        #endregion

        #region WorkingWithData
        public IEnumerable<TestResults> ResultsFilteredByAssessmentValue(IEnumerable<TestResults> testResults, int assessmentValue, bool isMoreThanValue)
        {
            if (testResults == null)
            {
                throw new ArgumentNullException(nameof(testResults), $"{nameof(testResults)} argument is a null");
            }

            testResults = isMoreThanValue ? testResults.Where(x => x.Assessment >= assessmentValue) : testResults.Where(x => x.Assessment <= assessmentValue);
            testResults = testResults.OrderBy(x => x.Assessment);
            return testResults;
        }

        public IEnumerable<TestResults> SortTestResults(IEnumerable<TestResults> testResults, SortingTypes sortingType, bool isAscending)
        {
            testResults = sortingType switch
            {
                SortingTypes.ByStudentName => from tr in testResults orderby tr.StudentName select tr,
                SortingTypes.ByTestName => from tr in testResults orderby tr.TestTitle select tr,
                SortingTypes.ByDate => from tr in testResults orderby tr.Date select tr,
                _ => from tr in testResults orderby tr.Assessment select tr
            };

            if (!isAscending)
            {
                testResults = testResults.Reverse();
            }

            return testResults;
        }
        #endregion

        #region FileReading
        public IEnumerable<TestResults> GetAllTestResults()
            => CombineIntoResponse(ReadingFileApproach.ReadAllData);

        public IEnumerable<TestResults> GetTestResultsByQuantity(int quantity)
            => CombineIntoResponse(ReadingFileApproach.ReadExactQuantity, quantity);

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
            using (var stream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                using (var reader = new BinaryReader(stream))
                {
                    Func<bool> predicate = readingFileApproach switch
                    {
                        ReadingFileApproach.ReadAllData => () => reader.PeekChar() != -1,
                        _ => () => reader.PeekChar() != -1 && counter < quantity
                    };

                    while (predicate.Invoke())
                    {
                        counter++;
                        yield return new TestResults
                        {
                            StudentName = reader.ReadString(),
                            TestTitle = reader.ReadString(),
                            Date = DateTime.Parse(reader.ReadString()),
                            Assessment = reader.ReadInt32()
                        };
                    }
                }
            }
        }
        #endregion

        public void InitializeFile()
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

            int studentsCount = _data.StudentsNames.Count;
            int testsCount = _data.TestsTitles.Count;
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    for (int studentId = 0, testId = 0; studentId < studentsCount; studentId++, testId++)
                    {
                        writer.Write(_data.StudentsNames[studentId]);
                        testId = testId == testsCount ? 0 : testId;
                        writer.Write(_data.TestsTitles[testId]);
                        writer.Write(_data.Dates[testId].ToString());
                        writer.Write(_data.Assessments[studentId]);
                    }
                }
            }
        }

        public void ClearFile()
        {
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                stream.SetLength(0);
            }
        }
    }
}
