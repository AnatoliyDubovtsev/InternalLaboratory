using NUnit.Framework;
using System;
using System.IO;

namespace Module3.Tests
{
    public class SortConfigurationTests
    {
        [TestCase("0")]
        [TestCase("1")]
        [TestCase("2")]
        public void ChooseSortingStrategy_InputCorrectNumber_ReturnsSortingStrategy(string input)
        {
            //arrange
            using var reader = new StringReader(input);
            Console.SetIn(reader);

            //act
            var result = Task2.SortingConfiguration.ChooseSortingStrategy();

            //assert
            Assert.IsInstanceOf<Task2.ISortingStrategy>(result);
        }

        [TestCase("a\n1", "Entered data is not a number. Please, try again")]
        [TestCase("-1\n1", "Sorting strategy is not found. Please, try again")]
        public void ChooseSortingStrategy_InputIncorrectData_ReturnsMessage(string input, string expectedMessage)
        {
            //arrange
            using var reader = new StringReader(input);
            using var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            //act
            _ = Task2.SortingConfiguration.ChooseSortingStrategy();
            var actualMessage = writer.ToString();

            //assert
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        [TestCase("A", true)]
        [TestCase("D", false)]
        public void ChooseTypeOfSorting_InputCorrectData_ReturnsBoolean(string input, bool expected)
        {
            //arrange
            using var reader = new StringReader(input);
            using var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            //act
            Task2.SortingConfiguration.ChooseTypeOfSorting(out bool isAscending);

            //assert
            Assert.AreEqual(expected, isAscending);
        }

        [TestCase("r\nA", "Entered data is incorrect. Please, try again")]
        [TestCase("r\nd", "Entered data is incorrect. Please, try again")]
        public void ChooseTypeOfSorting_InputIncorrectData_ReturnsMessage(string input, string expectedMessage)
        {
            //arrange
            using var reader = new StringReader(input);
            using var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            //act
            Task2.SortingConfiguration.ChooseTypeOfSorting(out bool isAscending);
            var actualMessage = writer.ToString();

            //assert
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        [TestCase(-1, ExpectedResult = null)]
        public Task2.ISortingStrategy GetSortingStrategy_InputIncorrectData_ReturnsNull(int input)
            => Task2.SortingConfiguration.GetSortingStrategy(input);
    }
}
