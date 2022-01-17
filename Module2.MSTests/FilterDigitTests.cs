using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Module2.MSTests
{
    [TestClass]
    public class FilterDigitTests
    {
        private const string _provider = @"Microsoft.VisualStudio.TestTools.DataSource.XML";
        private const string _connectionString = "ExternalFilesForDDT/FilterDigitTestData.xml";
        private const string _tableName = "Data";

        public TestContext TestContext { get; set; }

        [DataSource(_provider, _connectionString, _tableName, DataAccessMethod.Sequential)]
        [TestMethod()]
        public void FilterDigit_ReturnsResultArr()
        {
            //arrange
            string inputArrString = TestContext.DataRow["inputArray"].ToString();
            int digit = Convert.ToInt32(TestContext.DataRow["digit"]);
            string expectedString = TestContext.DataRow["outputArray"].ToString();
            int[] inputArr = FromStringArray(inputArrString);
            int[] expected = FromStringArray(expectedString);

            //act
            int[] actual = Task6.FilterDigit(inputArr, digit);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        private int[] FromStringArray(string stringArr)
        {
            if (stringArr.Length == 0)
            {
                return new int [] { };
            }

            string[] splittedString = stringArr.Split(' ');
            int[] resultArr = new int[splittedString.Length];
            for (int i = 0; i < splittedString.Length; i++)
            {
                resultArr[i] = Convert.ToInt32(splittedString[i]);
            }

            return resultArr;
        }
    }
}
