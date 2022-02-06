using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11
{
    public class Task1
    {
        private const string _path = @"..\..\..\..\Module11\Results.txt";

        public Task1()
        {
            InitializeFile();
        }

        public IEnumerable<TestResults> GetTestResults()
        {
            IEnumerable<TestResults> testResults = Array.Empty<TestResults>();
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream))
                {
                    while (reader.PeekChar() != -1)
                    {
                        testResults = testResults.Append<TestResults>(new TestResults
                        {
                            StudentName = reader.ReadString(),
                            TestName = reader.ReadString(),
                            Date = DateTime.Parse(reader.ReadString()),
                            Assessment = reader.ReadInt32()
                        });
                    }
                }
            }

            return testResults;
        }

        public IEnumerable<TestResults> ResultsWithAssessmentMoreThanInputValue(IEnumerable<TestResults> testResults, int assessmentValue)
        {
            return testResults.Where(x => x.Assessment > assessmentValue).OrderBy(x => x.StudentName).Select(x => x);
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
