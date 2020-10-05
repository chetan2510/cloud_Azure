namespace MyExperiment.Models
{
   /// <summary>
   /// This class represents the input data model of SE project
   /// </summary>
    public class SeProjectInputDataModel
    {
        public double Alpha { get; set; }
        public int BucketIndex { get; set; }
        public float ActualValueInBucket { get; set; }
        public int[] InputFromTemporalMemory { get; set; }
    }
}