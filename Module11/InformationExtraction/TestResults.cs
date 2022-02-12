using System;

namespace Module11.InformationExtraction
{
    public class TestResults : TestResultsStudentNameTestTitleAssessment
    {
        public DateTime Date { get; set; }

        public override string ToString() => base.ToString() + $"; Date: {Date}";        
    }
}
