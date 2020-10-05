using System.IO;
using NUnit.Framework;
namespace MyCloudTests.pojo
{
    public class DirectoryNotFoundExceptionTest
    {
        /// <summary>
        /// this method is checking if the exception is thrown when the directory not found message appears
        /// </summary>
        [Test]
        public void DirectoryNotFoundExceptionTest_IfExceptionIsThrown()
        {
            DirectoryNotFoundException directoryNotFoundException = new DirectoryNotFoundException("Directory not found exception");
            
            Assert.AreEqual("Directory not found exception", directoryNotFoundException.Message);
            
            
        }
    }
}