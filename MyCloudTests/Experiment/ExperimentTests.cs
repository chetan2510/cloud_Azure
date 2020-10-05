using NUnit.Framework;
using System;
using System.IO;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OData.UriParser;
using MyCloudProject.Common;
using MyExperiment.CloudStorages;
using MyExperiment.Utilities;
using System.Collections.Generic;
using Azure.Core;
using Newtonsoft.Json;



namespace MyCloudTests.Experiment
{
    public class ExperimentTests
    {
        /// <summary>
        /// Tests the creation of constructor
        /// </summary>
        [Test]
        public void TestIfConstructorIsGettingCreated()
        {
            var cfgRoot = InitHelpers.InitConfiguration(null);

            var cfgSec = cfgRoot.GetSection("MyConfig");
            var storage = A.Fake<IStorageProvider>();
            var log = A.Fake<ILogger>();
            MyExperiment.Experiment experiment = new MyExperiment.Experiment(cfgSec, storage, log);
            Assert.IsNotNull(experiment);
        }
        
        /// <summary>
        /// This test checks if the experiment is running for the SE Project using some random input data.
        /// </summary>
        [Test]
        public void TestRunMethod_WithRandomInputData()
        {
            var cfgRoot = InitHelpers.InitConfiguration(null);

            var cfgSec = cfgRoot.GetSection("MyConfig");

            var storage = A.Fake<IStorageProvider>();
            var log = A.Fake<ILogger>();
            MyExperiment.Experiment experiment = new MyExperiment.Experiment(cfgSec, storage, log);
            var result = experiment.Run("Experiment/DataForTesting/InputData.json");
            Assert.NotNull(result.Result);
            Assert.AreEqual("SDRClassifier", result.Result.Name);
        }
    }

} 