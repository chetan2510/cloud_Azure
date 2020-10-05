using Microsoft.Azure.Cosmos.Table;
using System;

namespace MyCloudProject.Common
{
    public class ExperimentResult : TableEntity
    {
        public ExperimentResult(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTimeUtc { get; set; }

        public DateTime EndTimeUtc { get; set; }

        public long DurationSec { get; set; }

        public string InputFileUrl { get; set; }
        
        public string SeExperimentOutputFileUrl { get; set; }
        
        public string SeExperimentOutputBlobUrl { get; set; }

    }
}
