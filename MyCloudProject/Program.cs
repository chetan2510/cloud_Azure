using MyCloudProject.Common;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading;
using MyExperiment;
using MyExperiment.CloudStorages;

namespace MyCloudProject
{
    class Program
    {
        /// <summary>
        /// Your project ID from the last semester.
        /// </summary>
        private static string projectName = "ML19/20-5.8"; //TODO

        static void Main(string[] args)
        {
            CancellationTokenSource tokeSrc = new CancellationTokenSource();

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                tokeSrc.Cancel();
            };

            Console.WriteLine($"Started experiment: {projectName}");

            //init configuration
            var cfgRoot = Common.InitHelpers.InitConfiguration(args);

            var cfgSec = cfgRoot.GetSection("MyConfig");

            // InitLogging
            var logFactory = InitHelpers.InitLogging(cfgRoot);
            var logger = logFactory.CreateLogger("Train.Console");

            logger?.LogInformation($"{DateTime.Now} -  Started experiment: {projectName}");

            IStorageProvider storageProvider = new AzureBlobOperations(cfgSec);

            Experiment experiment = new Experiment(cfgSec, storageProvider, logger/* put some additional config here */);

            experiment.RunQueueListener(tokeSrc.Token).Wait();

            logger?.LogInformation($"{DateTime.Now} -  Experiment exit: {projectName}");
        }

    }
}
