using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MyExperiment.Exceptions;

namespace MyCloudTests.Exceptions
{
    public class DirectoryNotFoundExceptionTests
    {
        /// <summary>
        /// This test checks for exception when there is no Directory found
        /// </summary>
        [Test]
        public void TestForDirectoryNotFoundException()
        {
            DirectoryNotFoundException directoryNotFoundException = new DirectoryNotFoundException("Directory not found exception");
            
            Assert.AreEqual("Directory not found exception", directoryNotFoundException.Message);

        }

    }
}
