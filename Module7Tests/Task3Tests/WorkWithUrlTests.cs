using Module7.Task3;
using NUnit.Framework;
using System;

namespace Module7Tests.Task3Tests
{
    public class WorkWithUrlTests
    {
        [TestCase(null, "key")]
        [TestCase("url", null)]
        [TestCase("", "key")]
        [TestCase("url", "")]
        public void AddOrChangeUrlParameter_NullOrEmptyStringInput_ThrowsArgumentNullException(string url, string keyValueParameter)
            => Assert.Throws<ArgumentNullException>(() => WorkWithUrl.AddOrChangeUrlParameter(url, keyValueParameter));

        [TestCase("www.example.com", "key=value", "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", "www.example.com?key=value&&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", "www.example.com?key=newValue")]
        [TestCase("www.example.com?key1=oldValue1&&key2=oldValue2", "key1=newValue1", "www.example.com?key1=newValue1&&key2=oldValue2")]
        [TestCase("www.example.com?key1=oldValue1&&key2=oldValue2", "key2=newValue2", "www.example.com?key1=oldValue1&&key2=newValue2")]
        [TestCase("  www.example.com?key1=oldValue1&&key2=oldValue2    ", "   key2=newValue2   ", "www.example.com?key1=oldValue1&&key2=newValue2")]
        public void AddOrChangeUrlParameter_CorrectInput_ReturnsResultString(string url, string keyValueParameter, string expected)
        {
            var result = WorkWithUrl.AddOrChangeUrlParameter(url, keyValueParameter);
            Assert.AreEqual(expected, result);
        }
    }
}
