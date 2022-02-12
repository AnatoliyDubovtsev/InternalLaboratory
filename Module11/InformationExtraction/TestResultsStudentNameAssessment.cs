using System;

namespace Module11.InformationExtraction
{
    public class TestResultsStudentNameAssessment : IComparable<TestResultsStudentNameAssessment>
    {
        public string StudentName { get; set; }
        public int Assessment { get; set; }

        public int CompareTo(TestResultsStudentNameAssessment other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), $"Argument '{nameof(other)}' is a null");
            }

            return ToString().CompareTo(other.ToString());
        }

        public override string ToString() => $"Student Name {StudentName}; Assessment: {Assessment}";

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return CompareTo((TestResultsStudentNameAssessment)obj) == 0;
        }

        public override int GetHashCode() => ToString().GetHashCode();

        public static bool operator ==(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right) => !(left == right);

        public static bool operator <(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right)
            => ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;

        public static bool operator <=(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right)
            => ReferenceEquals(left, null) || left.CompareTo(right) <= 0;

        public static bool operator >(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right)
            => !ReferenceEquals(left, null) && left.CompareTo(right) > 0;

        public static bool operator >=(TestResultsStudentNameAssessment left, TestResultsStudentNameAssessment right)
            => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
    }
}
