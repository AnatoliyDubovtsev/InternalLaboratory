using System;

namespace Module11.InformationExtraction
{
    public class TestResults : TestResultsStudentNameTestTitleAssessment, IComparable<TestResults>
    {
        public DateTime Date { get; set; }

        public int CompareTo(TestResults other)
        {
            return ToString().CompareTo(other.ToString());
        }

        public override string ToString() => base.ToString() + $"; Date: {Date}";

        public override bool Equals(object obj) => CompareTo((TestResults)obj) == 0;

        public override int GetHashCode() => ToString().GetHashCode();

        public static bool operator ==(TestResults left, TestResults right) => left.Equals(right);

        public static bool operator !=(TestResults left, TestResults right) => !(left == right);

        public static bool operator <(TestResults left, TestResults right) => left.CompareTo(right) < 0;

        public static bool operator <=(TestResults left, TestResults right) => left.CompareTo(right) <= 0;

        public static bool operator >(TestResults left, TestResults right) => left.CompareTo(right) > 0;

        public static bool operator >=(TestResults left, TestResults right) => left.CompareTo(right) >= 0;
    }
}
