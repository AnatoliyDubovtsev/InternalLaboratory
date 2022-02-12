using System;

namespace Module11.InformationExtraction
{
    public class TestResultsTestTitleDate : IComparable<TestResultsTestTitleDate>
    {
        public string TestTitle { get; set; }
        public DateTime Date { get; set; }

        public int CompareTo(TestResultsTestTitleDate other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), $"Argument '{nameof(other)}' is a null");
            }

            return ToString().CompareTo(other.ToString());
        }

        public override string ToString() => $"Test title: {TestTitle}; Date: {Date}";

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return CompareTo((TestResultsTestTitleDate)obj) == 0;
        }

        public override int GetHashCode() => ToString().GetHashCode();

        public static bool operator ==(TestResultsTestTitleDate left, TestResultsTestTitleDate right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(TestResultsTestTitleDate left, TestResultsTestTitleDate right) => !(left == right);

        public static bool operator <(TestResultsTestTitleDate left, TestResultsTestTitleDate right)
            => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(TestResultsTestTitleDate left, TestResultsTestTitleDate right)
            => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator >(TestResultsTestTitleDate left, TestResultsTestTitleDate right)
            => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(TestResultsTestTitleDate left, TestResultsTestTitleDate right)
            => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
    }
}
