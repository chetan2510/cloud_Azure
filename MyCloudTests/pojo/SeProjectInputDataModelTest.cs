using MyExperiment.Models;
using NUnit.Framework;

namespace MyCloudTests.pojo
{
    public class SeProjectInputDataModelTest
    {
        /// <summary>
        /// This method is checking if the SeProjectInputDataModel is not null
        /// </summary>
        [Test]
        public void TestIfObjectIsNotNull()
        {
            SeProjectInputDataModel seProjectInputDataModel = new SeProjectInputDataModel();
            Assert.NotNull(seProjectInputDataModel);
        }
        /// <summary>
        /// This method is checking if the values are assigned to the input data model
        /// </summary>
        [Test]
        public void TestIfValuesAreAssigned()
        {
            SeProjectInputDataModel  values= new SeProjectInputDataModel();
            values.Alpha=2;
            values.BucketIndex=3;
            values.ActualValueInBucket=5;
            values.InputFromTemporalMemory = new[] {1, 2, 3};
            Assert.AreEqual(2,values.Alpha);
            Assert.AreEqual(3,values.BucketIndex); 
            Assert.AreEqual(5, values.ActualValueInBucket);
            Assert.AreEqual(1, values.InputFromTemporalMemory[0]);
            
        }
    }
}