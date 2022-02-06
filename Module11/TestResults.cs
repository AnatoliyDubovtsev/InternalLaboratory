using System;

namespace Module11
{
    public class TestResults
    {
        public string StudentName { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }
        public int Assessment { get; set; }

        public override string ToString()
        {
            return $"Student: {StudentName}; Test: {TestName}; Date: {Date.ToShortDateString()}; Assessment: {Assessment}";
        }
    }
}
