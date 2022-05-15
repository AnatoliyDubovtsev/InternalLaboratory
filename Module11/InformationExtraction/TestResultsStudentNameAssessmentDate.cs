using System;

namespace Module11.InformationExtraction
{
    public class TestResultsStudentNameAssessmentDate : TestResultsStudentNameAssessment
    {
        public DateTime Date { get; set; }

        public override string ToString() => base.ToString() + $"; Date: {Date}";
    }
}
