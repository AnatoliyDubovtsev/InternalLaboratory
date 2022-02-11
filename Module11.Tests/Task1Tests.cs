using Module11.Enums;
using Module11.InformationExtraction;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module11.Tests
{
    public class Task1Tests
    {
        private const string _path = @"..\..\..\..\Module11.Tests\Tests.txt";
        
        private static Data _testsData = new Data
        {
            StudentsNames = new List<string> { "1 Tests Student", "2 Student For Tests", "Student For Tests 3", "Tests Student 4" },
            TestsTitles = new List<string> { "Test Title 1", "Test Title 2" },
            Dates = new List<DateTime> { new DateTime(2022, 10, 20, 10, 30, 0), new DateTime(2022, 5, 25, 12, 0, 0) },
            Assessments = new List<int> { 10, 8, 9, 7 }
        };

        private static TestResults[] _testResults = new TestResults[]
                    {
                        new TestResults
                        {
                            StudentName = _testsData.StudentsNames[0],
                            TestTitle = _testsData.TestsTitles[0],
                            Date = _testsData.Dates[0],
                            Assessment = _testsData.Assessments[0]
                        },
                        new TestResults
                        {
                            StudentName = _testsData.StudentsNames[1],
                            TestTitle = _testsData.TestsTitles[1],
                            Date = _testsData.Dates[1],
                            Assessment = _testsData.Assessments[1]
                        },
                        new TestResults
                        {
                            StudentName = _testsData.StudentsNames[2],
                            TestTitle = _testsData.TestsTitles[0],
                            Date = _testsData.Dates[0],
                            Assessment = _testsData.Assessments[2]
                        },
                        new TestResults
                        {
                            StudentName = _testsData.StudentsNames[3],
                            TestTitle = _testsData.TestsTitles[1],
                            Date = _testsData.Dates[1],
                            Assessment = _testsData.Assessments[3]
                        }
                    };

        private static TestResultsStudentName[] _testResultsStudentNames = new TestResultsStudentName[]
                    {
                        new TestResultsStudentName { StudentName = _testsData.StudentsNames[0] },
                        new TestResultsStudentName { StudentName = _testsData.StudentsNames[1] },
                        new TestResultsStudentName { StudentName = _testsData.StudentsNames[2] },
                        new TestResultsStudentName { StudentName = _testsData.StudentsNames[3] }
                    };

        private static TestResultsStudentNameAssessment[] _testResultsStudentNamesAssessments = new TestResultsStudentNameAssessment[]
                    {
                        new TestResultsStudentNameAssessment
                        {
                            StudentName = _testsData.StudentsNames[0],
                            Assessment = _testsData.Assessments[0]
                        },
                        new TestResultsStudentNameAssessment
                        {
                            StudentName = _testsData.StudentsNames[1],
                            Assessment = _testsData.Assessments[1]
                        },
                        new TestResultsStudentNameAssessment
                        {
                            StudentName = _testsData.StudentsNames[2],
                            Assessment = _testsData.Assessments[2]
                        },
                        new TestResultsStudentNameAssessment
                        {
                            StudentName = _testsData.StudentsNames[3],
                            Assessment = _testsData.Assessments[3]
                        }
                    };

        private static TestResultsStudentNameAssessmentDate[] _testResultsStudentNamesAssessmentsDates = new TestResultsStudentNameAssessmentDate[]
                    {
                        new TestResultsStudentNameAssessmentDate
                        {
                            StudentName = _testsData.StudentsNames[0],
                            Date = _testsData.Dates[0],
                            Assessment = _testsData.Assessments[0]
                        },
                        new TestResultsStudentNameAssessmentDate
                        {
                            StudentName = _testsData.StudentsNames[1],
                            Date = _testsData.Dates[1],
                            Assessment = _testsData.Assessments[1]
                        },
                        new TestResultsStudentNameAssessmentDate
                        {
                            StudentName = _testsData.StudentsNames[2],
                            Date = _testsData.Dates[0],
                            Assessment = _testsData.Assessments[2]
                        },
                        new TestResultsStudentNameAssessmentDate
                        {
                            StudentName = _testsData.StudentsNames[3],
                            Date = _testsData.Dates[1],
                            Assessment = _testsData.Assessments[3]
                        }
                    };

        private static TestResultsStudentNameTestTitleAssessment[] _testResultsStudentNamesTestTitlesAssessments = new TestResultsStudentNameTestTitleAssessment[]
                    {
                        new TestResultsStudentNameTestTitleAssessment
                        {
                            StudentName = _testsData.StudentsNames[0],
                            TestTitle = _testsData.TestsTitles[0],
                            Assessment = _testsData.Assessments[0]
                        },
                        new TestResultsStudentNameTestTitleAssessment
                        {
                            StudentName = _testsData.StudentsNames[1],
                            TestTitle = _testsData.TestsTitles[1],
                            Assessment = _testsData.Assessments[1]
                        },
                        new TestResultsStudentNameTestTitleAssessment
                        {
                            StudentName = _testsData.StudentsNames[2],
                            TestTitle = _testsData.TestsTitles[0],
                            Assessment = _testsData.Assessments[2]
                        },
                        new TestResultsStudentNameTestTitleAssessment
                        {
                            StudentName = _testsData.StudentsNames[3],
                            TestTitle = _testsData.TestsTitles[1],
                            Assessment = _testsData.Assessments[3]
                        }
                    };

        private static TestResultsTestTitleDate[] _testResultsTestTitlesDates = new TestResultsTestTitleDate[]
                    {
                        new TestResultsTestTitleDate
                        {
                            TestTitle = _testsData.TestsTitles[0],
                            Date = _testsData.Dates[0]
                        },
                        new TestResultsTestTitleDate
                        {
                            TestTitle = _testsData.TestsTitles[1],
                            Date = _testsData.Dates[1]
                        },
                        new TestResultsTestTitleDate
                        {
                            TestTitle = _testsData.TestsTitles[0],
                            Date = _testsData.Dates[0]
                        },
                        new TestResultsTestTitleDate
                        {
                            TestTitle = _testsData.TestsTitles[1],
                            Date = _testsData.Dates[1]
                        }
                    };


        public static IEnumerable GetAllTestResults_TestCases
        {
            get
            {
                yield return new TestCaseData(_testsData, _testResults);
                yield return new TestCaseData(
                    new Data
                    {
                        StudentsNames = new List<string> { "1 Tests Student" },
                        TestsTitles = new List<string> { "Test Title 1" },
                        Dates = new List<DateTime> { new DateTime(2022, 10, 20, 10, 30, 0) },
                        Assessments = new List<int> { 10 }
                    },
                    new TestResults[]
                    {
                        _testResults[0]
                    });
            }
        }

        public static IEnumerable GetAllTestResultsByQuantity_TestCases
        {
            get
            {
                yield return new TestCaseData(_testsData, 2, new TestResults[] { _testResults[0], _testResults[1] });
                yield return new TestCaseData(_testsData, 0, new TestResults[] { });
                yield return new TestCaseData(_testsData, 4, _testResults);
                yield return new TestCaseData(_testsData, 10, _testResults);
            }
        }

        public static IEnumerable SortTestResults_TestCases
        {
            get
            {
                yield return new TestCaseData(_testResults, SortingTypes.ByAssessment, true,
                    new TestResults[] { _testResults[3], _testResults[1], _testResults[2], _testResults[0] });
                yield return new TestCaseData(_testResults, SortingTypes.ByAssessment, false,
                    new TestResults[] { _testResults[0], _testResults[2], _testResults[1], _testResults[3] });

                yield return new TestCaseData(_testResults, SortingTypes.ByDate, true,
                    new TestResults[] { _testResults[1], _testResults[3], _testResults[0], _testResults[2] });
                yield return new TestCaseData(_testResults, SortingTypes.ByDate, false,
                    new TestResults[] { _testResults[2], _testResults[0], _testResults[3], _testResults[1] });

                yield return new TestCaseData(_testResults, SortingTypes.ByStudentName, true,
                    new TestResults[] { _testResults[0], _testResults[1], _testResults[2], _testResults[3] });
                yield return new TestCaseData(_testResults, SortingTypes.ByStudentName, false,
                    new TestResults[] { _testResults[3], _testResults[2], _testResults[1], _testResults[0] });

                yield return new TestCaseData(_testResults, SortingTypes.ByTestName, true,
                    new TestResults[] { _testResults[0], _testResults[2], _testResults[1], _testResults[3] });
                yield return new TestCaseData(_testResults, SortingTypes.ByTestName, false,
                    new TestResults[] { _testResults[3], _testResults[1], _testResults[2], _testResults[0] });
            }
        }

        public static IEnumerable ResultsFilteredByAssessmentValue_TestCases
        {
            get
            {
                #region Type_TestResults
                yield return new TestCaseData(_testResults, 5, true, new TestResults[] { _testResults[3], _testResults[1], _testResults[2], _testResults[0] });
                yield return new TestCaseData(_testResults, 5, false, new TestResults[] { });
                yield return new TestCaseData(_testResults, 10, true, new TestResults[] { _testResults[0] });
                yield return new TestCaseData(_testResults, 10, false, new TestResults[] { _testResults[3], _testResults[1], _testResults[2], _testResults[0] });
                yield return new TestCaseData(_testResults, 15, true, new TestResults[] { });
                yield return new TestCaseData(_testResults, 15, false, new TestResults[] { _testResults[3], _testResults[1], _testResults[2], _testResults[0] });
                #endregion

                #region Type_TestResultsStudentNameAssessment
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 5, true,
                    new TestResultsStudentNameAssessment[]
                        { 
                            _testResultsStudentNamesAssessments[3], _testResultsStudentNamesAssessments[1],
                            _testResultsStudentNamesAssessments[2], _testResultsStudentNamesAssessments[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 5, false, new TestResultsStudentNameAssessment[] { });
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 10, true,
                    new TestResultsStudentNameAssessment[] { _testResultsStudentNamesAssessments[0] });
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 10, false,
                    new TestResultsStudentNameAssessment[]
                        {
                            _testResultsStudentNamesAssessments[3], _testResultsStudentNamesAssessments[1],
                            _testResultsStudentNamesAssessments[2], _testResultsStudentNamesAssessments[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 15, true, new TestResultsStudentNameAssessment[] { });
                yield return new TestCaseData(_testResultsStudentNamesAssessments, 15, false,
                    new TestResultsStudentNameAssessment[]
                        { 
                            _testResultsStudentNamesAssessments[3], _testResultsStudentNamesAssessments[1],
                            _testResultsStudentNamesAssessments[2], _testResultsStudentNamesAssessments[0]
                        });
                #endregion

                #region Type_TestResultsStudentNameAssessmentDate
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 5, true,
                    new TestResultsStudentNameAssessmentDate[]
                        {
                            _testResultsStudentNamesAssessmentsDates[3], _testResultsStudentNamesAssessmentsDates[1],
                            _testResultsStudentNamesAssessmentsDates[2], _testResultsStudentNamesAssessmentsDates[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 5, false, new TestResultsStudentNameAssessmentDate[] { });
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 10, true,
                    new TestResultsStudentNameAssessmentDate[] { _testResultsStudentNamesAssessmentsDates[0] });
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 10, false,
                    new TestResultsStudentNameAssessmentDate[]
                        { 
                            _testResultsStudentNamesAssessmentsDates[3], _testResultsStudentNamesAssessmentsDates[1],
                            _testResultsStudentNamesAssessmentsDates[2], _testResultsStudentNamesAssessmentsDates[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 15, true, new TestResultsStudentNameAssessmentDate[] { });
                yield return new TestCaseData(_testResultsStudentNamesAssessmentsDates, 15, false,
                    new TestResultsStudentNameAssessmentDate[]
                        {
                            _testResultsStudentNamesAssessmentsDates[3], _testResultsStudentNamesAssessmentsDates[1],
                            _testResultsStudentNamesAssessmentsDates[2], _testResultsStudentNamesAssessmentsDates[0]
                        });
                #endregion

                #region Type_TestResultsStudentNameTestTitleAssessment
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 5, true,
                    new TestResultsStudentNameTestTitleAssessment[]
                        {
                            _testResultsStudentNamesTestTitlesAssessments[3], _testResultsStudentNamesTestTitlesAssessments[1],
                            _testResultsStudentNamesTestTitlesAssessments[2], _testResultsStudentNamesTestTitlesAssessments[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 5, false, new TestResultsStudentNameTestTitleAssessment[] { });
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 10, true,
                    new TestResultsStudentNameTestTitleAssessment[] { _testResultsStudentNamesTestTitlesAssessments[0] });
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 10, false,
                    new TestResultsStudentNameTestTitleAssessment[]
                        {
                            _testResultsStudentNamesTestTitlesAssessments[3], _testResultsStudentNamesTestTitlesAssessments[1],
                            _testResultsStudentNamesTestTitlesAssessments[2], _testResultsStudentNamesTestTitlesAssessments[0]
                        });
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 15, true, new TestResultsStudentNameTestTitleAssessment[] { });
                yield return new TestCaseData(_testResultsStudentNamesTestTitlesAssessments, 15, false,
                    new TestResultsStudentNameTestTitleAssessment[]
                        {
                            _testResultsStudentNamesTestTitlesAssessments[3], _testResultsStudentNamesTestTitlesAssessments[1],
                            _testResultsStudentNamesTestTitlesAssessments[2], _testResultsStudentNamesTestTitlesAssessments[0]
                        });
                #endregion
            }
        }

        public static IEnumerable ExtractStudentNamesFromCollection_TestCases
        {
            get
            {
                yield return new TestCaseData(_testResults, _testResultsStudentNames);
            }
        }

        [Test]
        public void Initialize_FillingTheFile()
        {
            //arrange
            var task = new Task1(_path, _testsData);
            task.InitializeFile();
            long length;
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                //act
                length = stream.Length;
            }

            task.ClearFile();

            //assert
            Assert.AreNotEqual(0, length);
        }

        [Test]
        public void ClearFile()
        {
            //arrange
            var task = new Task1(_path, _testsData);
            task.InitializeFile();
            long length;

            //act
            task.ClearFile();
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                length = stream.Length;
            }

            //assert
            Assert.AreEqual(0, length);
        }

        [TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.GetAllTestResults_TestCases))]
        public void GetAllTestResults_ReadAllFile(Data data, TestResults[] expected)
        {
            //arrange
            var task = new Task1(_path, data);
            task.InitializeFile();

            //act
            var actual = task.GetAllTestResults().ToArray();
            task.ClearFile();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.GetAllTestResultsByQuantity_TestCases))]
        public void GetAllTestResultsByQuantity_ReturnsTestResultsCollection(Data data, int quantity, TestResults[] expected)
        {
            //arrange
            var task = new Task1(_path, data);
            task.InitializeFile();

            //act
            var actual = task.GetTestResultsByQuantity(quantity).ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.SortTestResults_TestCases))]
        public void SortTestResults_ReturnsSortedCollection(TestResults[] testResults, SortingTypes sortingType, bool isAscending, TestResults[] expected)
        {
            //arrange
            var task = new Task1();

            //act
            var actual = task.SortTestResults(testResults, sortingType, isAscending).ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.ResultsFilteredByAssessmentValue_TestCases))]
        public void ResultsFilteredByAssessmentValue_ReturnsCollection<T>(T[] testResults, int assessmentValue, bool isMoreThanValue, T[] expected)
            where T : TestResultsStudentNameAssessment
        {
            //arrange
            var task = new Task1();

            //act
            var actual = task.ResultsFilteredByAssessmentValue<T>(testResults, assessmentValue, isMoreThanValue).ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /*[TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.ExtractStudentNamesFromCollection_TestCases))]
        public void ExtractStudentNamesFromCollection_ReturnsCollection(TestResults[] testResults, TestResultsStudentName[] expected)
        {
            //arrange
            var task = new Task1();

            //act
            var actual = task.ExtractStudentNamesFromCollection(testResults).ToArray();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }*/

        //TODO ImplementIComparableInterfaceForInformationExtractionClasses
    }
}
