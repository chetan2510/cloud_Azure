using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyExperiment.Utilities;
using NUnit.Framework;

namespace MyCloudTests.Utilities
{
    public class FileUtilitiesTests
    {
        [Test]
        public void TestForFileUtilitieRead()
        {
            string expectedResult = File.ReadAllText("Utilities/TestFile.json");
            string path = "Utilities/TestFile.json";
            string jsonString = FileUtilities.ReadFile(path);
            Assert.AreEqual(expectedResult, jsonString);
        }
    }
}
