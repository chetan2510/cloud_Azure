using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class ExceptionConstantsTests
    {
        /// <summary>
        /// This test Validates the constant values
        /// </summary>
        [Test]
        public void TestForExceptionConstants()
        {
            Assert.AreEqual("Unable to predict, since bucket is empty", ExceptionConstants.EMPTY_BUCKET_EXCEPTION);
            Assert.AreEqual("Classification cannot be null", ExceptionConstants.CLASSIFICATION_CANNOT_BE_NULL);
            Assert.AreEqual("Pattern cannot be null or empty", ExceptionConstants.PATTERN_NZ_CANNOT_BE_NULL);
        }
    }
}