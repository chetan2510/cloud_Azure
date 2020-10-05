using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class EmptyBucketExceptionTests
    {
        /// <summary>
        /// This test checks for exception throwing in case of bucket doesn't contain any values.
        /// </summary>
        [Test]
        public void TestForEmptyBucketException()
        {
            EmptyBucketException ex = new EmptyBucketException("Empty bucket exception");
            Assert.AreEqual("Empty bucket exception", ex.Message);
        }
        
    }
}