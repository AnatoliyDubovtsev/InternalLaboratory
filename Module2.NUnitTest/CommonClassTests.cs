using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace Module2.NUnitTests
{
    public class CommonClassTests
    {
        [Test]
        public void ElapsedMilliseconds_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Common.ElapsedMilliseconds(null));

        [TestCase(true)]
        [TestCase(false)]
        public void ElapsedMilliseconds_ReturnsDoubleResult(bool isStopwatchStarted)
        {
            //arrange
            Stopwatch stopwatch = new Stopwatch();

            //act
            if (isStopwatchStarted)
            {
                stopwatch.Start();
                Thread.Sleep(5);
            }

            //assert
            if (isStopwatchStarted)
                Assert.True(0.0 < Common.ElapsedMilliseconds(stopwatch));
            else
                Assert.True(0.0 == Common.ElapsedMilliseconds(stopwatch));
        }

        [TestCase(5, 10, 10, 5)]
        public void SwapElements_ReturnsExpectedResult(int left, int right, int expectedLeft, int expectedRight)
        {
            Common.SwapElements<int>(ref left, ref right);
            Assert.AreEqual(left, expectedLeft);
            Assert.AreEqual(right, expectedRight);
        }
    }
}
