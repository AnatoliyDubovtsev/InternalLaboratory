using System;

namespace Module11.InformationExtraction
{
    public class TestResultsTestTitleDate
    {
        public string TestTitle { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => $"Test title: {TestTitle}; Date: {Date}";
    }
}
