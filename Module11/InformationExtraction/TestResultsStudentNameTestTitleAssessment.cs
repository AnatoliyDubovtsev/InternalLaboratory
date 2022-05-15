namespace Module11.InformationExtraction
{
    public class TestResultsStudentNameTestTitleAssessment : TestResultsStudentNameAssessment
    {
        public string TestTitle { get; set; }

        public override string ToString() => base.ToString() + $"; Test title: {TestTitle}";
    }
}
