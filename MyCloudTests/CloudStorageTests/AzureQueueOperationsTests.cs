using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloudProject.Common;
using MyExperiment.CloudStorages;
using NUnit.Framework;




namespace MyCloudTests.CloudStorageTests
{
    //<summary> 
    // Queue Presence Test : Check if the object 'result' contains the created queue 
    //</summary>
    public class AzureQueueOperationsTests
    {
        [Test]

        public void TestForCreateQueue()
        {
          var cfgRoot = InitHelpers.InitConfiguration(null);

          var cfgSec = cfgRoot.GetSection("MyConfig");
          
          var config = new MyExperiment.MyConfig();
          
          cfgSec.Bind(config);

          var log = A.Fake<ILogger>();
          
          var result = AzureQueueOperations.CreateQueueAsync(config, log);
            
          Assert.NotNull(result.Result);
        }
    }
}