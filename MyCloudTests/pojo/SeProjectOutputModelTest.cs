using MyExperiment.Models;
using NUnit.Framework;

namespace MyCloudTests.pojo
{
    public class SeProjectOutputModelTest
    {
        /// <summary>
        /// this method is checking if the object is not null
        /// </summary>
        [Test]
        public void TestIfTheObjectIsNotNull()

        {
            var output = new double[2];
            SeProjectOutputModel seProjectOutputModel = new SeProjectOutputModel(output);
            Assert.NotNull(seProjectOutputModel);
        }
    }
}