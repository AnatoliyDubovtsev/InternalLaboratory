namespace Module11.InformationExtraction
{
    public class TestResultsStudentNameAssessment : TestResultsStudentName
    {
        public int Assessment { get; set; }

        public override string ToString() => base.ToString() + $"; Assessment: {Assessment}";
    }
}
