using System;
using System.Collections.Generic;

namespace Module11
{
    public class Data
    {
        public List<string> StudentsNames { get; set; } = new List<string>
        {
            "Student 1",
            "Student 2",
            "Student 3",
            "Student 4",
            "Student 5",
            "Student 6",
            "Student 7",
            "Student 8",
            "Student 9",
            "Student 10"
        };

        public List<string> TestsNames { get; set; } = new List<string>
        {
            "Test 1",
            "Test 2",
            "Test 3",
            "Test 4"
        };

        public List<DateTime> Dates { get; set; } = new List<DateTime>
        {
            new DateTime(2001, 5, 20),
            new DateTime(2001, 5, 21),
            new DateTime(2001, 5, 22),
            new DateTime(2001, 5, 23)
        };

        public List<int> Assessments { get; set; } = new List<int> { 9, 5, 10, 7, 8, 9, 4, 6, 3, 2 };
    }
}
