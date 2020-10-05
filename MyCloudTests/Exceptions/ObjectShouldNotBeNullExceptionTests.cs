using Microsoft.Azure.Storage.Blob.Protocol;
using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class ObjectShouldNotBeNullExceptionTests
    {
        /// <summary>
        /// This test checks for exception if created object is null.
        /// </summary>
        [Test]
        public void TestForObjectShouldNotBeNullExceptionTests()
        {
            ObjectShouldNotBeNUllException ex = new ObjectShouldNotBeNUllException("Object should not be null exception");
            Assert.AreEqual("Object should not be null exception", ex.Message);
        }
    }
}