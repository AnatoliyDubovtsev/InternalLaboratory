using Module10.Task2;
using NUnit.Framework;
using System.Collections.Generic;

namespace Module10.Tests.Task2.Tests
{
    public class WorkWithFileTests
    {
        [Test]
        public void CountWordsInText_TextFile()
        {
            //arrange
            var expected = new Dictionary<string, int>
            {
                { "one", 3 },
                { "two", 2 },
                { "1", 3 },
                { "2", 2 }
            };

            //act
            var result = WorkWithFile.CountWordsInText(@"..\..\..\..\Module10\Task2\Text.txt");

            //assert
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void CountWordsInText_TextForTest1()
        {
            //arrange
            var expected = new Dictionary<string, int>
            {
                { "hot", 1 },
                { "reload", 1 },
                { "is", 2 },
                { "a", 1 },
                { "feature", 2 },
                { "that", 1 },
                { "lets", 1 },
                { "you", 1 },
                { "modify", 1 },
                { "your", 3 },
                { "app", 3 },
                { "s", 2 },
                { "source", 1 },
                { "code", 1 },
                { "and", 1 },
                { "instantly", 1},
                { "apply", 1 },
                { "those", 1 },
                { "changes", 1 },
                { "to", 2 },
                { "running", 1 },
                { "the", 1 },
                { "purpose", 1 },
                { "increase", 1 },
                { "productivity", 1 },
                { "by", 1 },
                { "avoiding", 1 },
                { "restarts", 1 },
                { "between", 1 },
                { "edits", 1 }
            };

            //act
            var result = WorkWithFile.CountWordsInText(@"..\..\..\Task2.Tests\TextForTest1.txt");

            //assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
