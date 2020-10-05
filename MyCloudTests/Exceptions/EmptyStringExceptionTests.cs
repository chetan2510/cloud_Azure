using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class EmptyStringExceptionTests
    {
        /// <summary>
        /// This test checks for exception in case of an empty string
        /// </summary>
        [Test]
        public void TestForEmptyStringException()
        {
            EmptyStringException ex = new EmptyStringException("Empty string exception");
            Assert.AreEqual("Empty string exception", ex.Message);
        }
    }
}