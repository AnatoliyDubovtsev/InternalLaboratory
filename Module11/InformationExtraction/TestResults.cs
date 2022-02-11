using System;

namespace Module11.InformationExtraction
{
    public class TestResults : IComparable<TestResults>
    {
        public string StudentName { get; set; }
        public string TestTitle { get; set; }
        public DateTime Date { get; set; }
        public int Assessment { get; set; }

        public int CompareTo(TestResults other)
        {
            return ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            return $"Student: {StudentName}; Test: {TestTitle}; Date: {Date}; Assessment: {Assessment}";
        }

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
