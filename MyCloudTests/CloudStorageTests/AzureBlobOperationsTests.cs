using System;
using System.IO;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OData.UriParser;
using MyCloudProject.Common;
using MyExperiment.CloudStorages;
using MyExperiment.Exceptions;
using NUnit.Framework;
using TypeMock;
using TypeMock.ArrangeActAssert;


namespace MyCloudTests.CloudStorageTests
{
    public class AzureBlobOperationsTests
    {
        
        // <summary>
        // Constructor Test: Testing presence of constructor of class under test
        //</summary>
        [Test]
        public void TestAzureBlobOperations_Constructor()
        { 
            var config = A.Fake<IConfigurationSection>();
            AzureBlobOperations azureBlobOperations = new AzureBlobOperations(config);
            Assert.IsNotNull(azureBlobOperations);
        }
        
        //<summary>
        //Exception Case: checks if Input file is passed
        //Throws EmptyStringException if null arguments are received
        //</summary>
        [Test]
        public void EmptyDownloadInputFile ()
        {
            var config =  A.Fake<IConfigurationSection>();
            AzureBlobOperations azureBlobOperations = new AzureBlobOperations(config);
            try
            {
                azureBlobOperations.DownloadInputFile(null);
            }
            catch (EmptyStringException ex)
            {
                Assert.AreEqual("File name cannot be empty or null", ex.Message);
            }
        }
       //<summary>
       // Tests if the file downloaded from Azure Container Blob is not null
       //</summary>
        [Test]
        public void TestAzureBlobOperations_DownloadFile()
        {

            var cfgRoot = InitHelpers.InitConfiguration(null);

            var cfgSec = cfgRoot.GetSection("MyConfig");
            var storage = A.Fake<IStorageProvider>();
            var log = A.Fake<ILogger>();
            AzureBlobOperations azureBlobOperations = new AzureBlobOperations(cfgSec);
            var result = azureBlobOperations.DownloadInputFile("Experiment/DataForTesting/InputData.json");
            
            Assert.NotNull(result);
            
        }
        
        //<summary>
        // Exception Case: Checks if file to be uploaded is not null
        //Throws ObjectShouldNotBeNUllException otherwise
        //</summary>
        [Test]
        public void TestIfResultToBeUploadedIs_NotNull()
        {
            var cfgRoot = InitHelpers.InitConfiguration(null);

            var cfgSec = cfgRoot.GetSection("MyConfig");
           
            AzureBlobOperations azureBlobOperations = new AzureBlobOperations(cfgSec);
            try
            {
                azureBlobOperations.UploadExperimentResult(null);
            }
            catch (ObjectShouldNotBeNUllException ex)
            {
                Assert.AreEqual("Result object cannot be null", ex.Message);
            }
        }
    }
}