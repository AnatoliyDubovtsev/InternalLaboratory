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

        public static IEnumerable DataForTests_TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Data
                    {
                        StudentsNames = new List<string> { "1 Tests Student", "2 Student For Tests", "Student For Tests 3", "Tests Student 4" },
                        TestsTitles = new List<string> { "Test Title 1", "Test Title 2" },
                        Dates = new List<DateTime> { new DateTime(2022, 10, 20, 10, 30, 0), new DateTime(2022, 5, 25, 12, 0, 0) },
                        Assessments = new List<int> { 10, 8, 9, 7 }
                    },
                    new TestResults[]
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
                        },
                    });
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

        [TestCaseSource(typeof(Task1Tests), nameof(Task1Tests.DataForTests_TestCases))]
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
    }
}
