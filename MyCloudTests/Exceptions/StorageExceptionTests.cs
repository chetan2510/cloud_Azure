using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class StorageExceptionTests
    {
        /// <summary>
        /// This test checks for an exception for a storage service
        /// </summary>
        [Test]
        public void TestForStorageException()
        {
            StorageException ex = new StorageException("Storage Exception");
            Assert.AreEqual("Storage Exception", ex.Message);
        }
    }
}