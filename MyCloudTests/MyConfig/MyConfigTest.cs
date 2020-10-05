using NUnit.Framework;

namespace MyCloudTests.MyConfig
{
    public class MyConfigTests
    {
        /// <summary>
        /// This test checks for the configuration of Project.
        /// </summary>
        [Test]
        public void TestForProjectConfigration()
        {
            MyExperiment.MyConfig values = new MyExperiment.MyConfig();
            values.StorageConnectionString = "StorageConnectionString";
            values.TrainingContainer = "TrainingContainer";
            values.ResultContainer = "ResultContainer";
            values.ResultTable = "ResultTable";
            values.Queue = "Queue";
            values.GroupId = "GroupId";
            values.StorageConnectionStringCosmosTable = "StorageConnectionStringCosmosTable";
            values.LocalPath = "LocalPath";
            Assert.AreEqual("StorageConnectionString", values.StorageConnectionString);
            Assert.AreEqual("TrainingContainer", values.TrainingContainer);
            Assert.AreEqual("ResultContainer", values.ResultContainer);
            Assert.AreEqual("ResultTable", values.ResultTable);
            Assert.AreEqual("Queue", values.Queue);
            Assert.AreEqual("GroupId", values.GroupId);
            Assert.AreEqual("StorageConnectionStringCosmosTable", values.StorageConnectionStringCosmosTable);
            Assert.AreEqual("LocalPath", values.LocalPath);
        }
        
    }
}