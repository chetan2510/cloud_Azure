using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyExperiment.CloudStorages;
using MyExperiment.Models;
using MyExperiment.SEProject;
using MyExperiment.Utilities;
using Newtonsoft.Json;

namespace MyExperiment
{
    public class Experiment : IExperiment
    {
        public static string DataFolder { get; private set; }
        private IStorageProvider storageProvider;
        private ILogger logger;
        private MyConfig config;

        /// <summary>
        /// Method configures the constructor and creates the directory for storing the input-data
        /// from blob storage
        /// </summary>
        /// <param name="configSection"></param>
        /// <param name="storageProvider"></param>
        /// <param name="log"></param>
        public Experiment(IConfigurationSection configSection, IStorageProvider storageProvider, ILogger log)
        {
            this.storageProvider = storageProvider;
            logger = log;
            config = new MyConfig();
            configSection.Bind(config);

            //  Creates the directory where the input-data from the blob will be stored
            DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                config.LocalPath);
            Directory.CreateDirectory(DataFolder);
        }

        /// <summary>
        /// Runs the project via data locally and update record of results received in addition
        /// to time stamps and duration 
        /// </summary>
        /// <param name="localFileName"></param>
        /// <returns></returns>
        public async Task<ExperimentResult> Run(string localFileName)
        {
            var seProjectInputDataList =
                JsonConvert.DeserializeObject<List<SeProjectInputDataModel>>(FileUtilities.ReadFile(localFileName));

            var startTime = DateTime.UtcNow;

            // running until the input ends
            string uploadedDataURI = await RunSoftwareEngineeringExperiment(seProjectInputDataList);

            // Added delay
            Thread.Sleep(5000);
            var endTime = DateTime.UtcNow;
            
            logger?.LogInformation(
                $"Ran the experiment SDRClassifier as per input from the blob storage");
            
            long duration = endTime.Subtract(startTime).Seconds;

            // Creating a result file over here.
            var res = new ExperimentResult(this.config.GroupId, Guid.NewGuid().ToString());
            UpdateExperimentResult(res, startTime, endTime, duration, localFileName, uploadedDataURI);
            return res;
        }

        /// <inheritdoc/>      
        public async Task RunQueueListener(CancellationToken cancelToken)
        {
            CloudQueue queue = await AzureQueueOperations.CreateQueueAsync(config, logger);

            while (cancelToken.IsCancellationRequested == false)
            {
                var message = await queue.GetMessageAsync(cancelToken);
                try
                {
                    if (message != null)
                    {
                        // STEP 1. Reading message from Queue and deserializing
                        var experimentRequestMessage =
                            JsonConvert.DeserializeObject<ExerimentRequestMessage>(message.AsString);
                        logger?.LogInformation(
                            $"Received message from the queue with experimentID: " +
                            $"{experimentRequestMessage.ExperimentId}, " +
                            $"description: {experimentRequestMessage.Description}, " +
                            $"name: {experimentRequestMessage.Name}");

                        // STEP 2. Downloading the input file from the blob storage
                        var fileToDownload = experimentRequestMessage.InputFile;
                        var localStorageFilePath = await storageProvider.DownloadInputFile(fileToDownload);

                        logger?.LogInformation(
                            $"File download successful. Downloaded file link: {localStorageFilePath}");

                        // STEP 3. Running SE experiment with inputs from the input file
                        var result = await Run(localStorageFilePath);
                        result.Description = experimentRequestMessage.Description;
                        var resultAsByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));

                        // STEP 4. Uploading result file to blob storage
                        var uploadedUri =
                            await storageProvider.UploadResultFile("ResultFile-" + Guid.NewGuid() + ".txt",
                                resultAsByte);
                        logger?.LogInformation($"Uploaded result file on blob");
                        result.SeExperimentOutputBlobUrl = Encoding.ASCII.GetString(uploadedUri);

                        // STEP 5. Uploading result file to table storage
                        await storageProvider.UploadExperimentResult(result);

                        // STEP 6. Deleting the message from the queue
                        await queue.DeleteMessageAsync(message, cancelToken);
                    }
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex, "Caught an exception: {0}", ex.Message);
                    await queue.DeleteMessageAsync(message, cancelToken);
                }

                // pause
                await Task.Delay(500, cancelToken);
            }

            logger?.LogInformation("Cancel pressed. Exiting the listener loop.");
        }

        /// <summary>
        /// Method updates the record for experiment result after successful running of the experiment
        /// </summary>
        /// <param name="experimentResult"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="duration"></param>
        /// <param name="downloadFileUrl"></param>
        /// <param name="testCaseOutputUri"></param>
        private static void UpdateExperimentResult(ExperimentResult experimentResult, DateTime startTime,
            DateTime endTime, long duration, string downloadFileUrl, string testCaseOutputUri)
        {
            experimentResult.StartTimeUtc = startTime;
            experimentResult.EndTimeUtc = endTime;
            experimentResult.DurationSec = duration;
            experimentResult.Name = "SDRClassifier";
            experimentResult.InputFileUrl = downloadFileUrl;
            experimentResult.SeExperimentOutputFileUrl = testCaseOutputUri;
        }

        /// <summary>
        /// Runs the experiment and uploads the results back onto the blob storage
        /// </summary>
        /// <param name="seProjectInputDataList"></param>
        /// <returns></returns>
        private async Task<string> RunSoftwareEngineeringExperiment(
            List<SeProjectInputDataModel> seProjectInputDataList)
        {
            // For the set of inputs alpha does not changes
            var sdr = new SdrClassifier(seProjectInputDataList[0].Alpha);

            // Step 1: Process the input-data in a file
            foreach (var input in seProjectInputDataList)
            {
                var classification = new List<object> {input.BucketIndex, input.ActualValueInBucket};

                // After this step bucket values will be updated
                sdr.Compute(0, classification, input.InputFromTemporalMemory);
                var predictionResult = sdr.Predict(input.InputFromTemporalMemory);
                var seProjectOutputModel = new SeProjectOutputModel(predictionResult);
                var outputAsByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(seProjectOutputModel));

                // Writing output in a file
                FileUtilities.WriteDataInFile("CombinedOutputOfSoftwareExperiment.txt", predictionResult, input.BucketIndex);
            }

            // Step 2: Uploading output to blob storage
            var uploadedUri =
                await storageProvider.
                UploadResultFile("CombinedOutputOfSoftwareExperiment.txt", null);
            logger?.LogInformation(
                $"Output of the SDRClassifier as a file uploaded successful. Blob URL: {Encoding.ASCII.GetString(uploadedUri)}");

            // return a string and delete the combined file if possible
            return Encoding.ASCII.GetString(uploadedUri);
        }
    }
}