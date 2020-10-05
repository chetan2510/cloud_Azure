namespace MyExperiment.Models
{
    public class SeProjectOutputModel
    {
        /// <summary>
        /// This class represents the output model of the SE project
        /// </summary>
        private double[] Output { get; set; }

        public SeProjectOutputModel(double[] output)
        {
            Output = output;
        }
    }
}