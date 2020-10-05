using System.IO;

namespace MyExperiment.Utilities
{
    public static class FileUtilities
    {
        /// <summary>
        /// Reading the text 
        /// </summary>
        /// <param name="localfilePath"></param>
        /// <returns></returns>
        public static string ReadFile(string localFilePath)
        {
            string jsonString = File.ReadAllText(localFilePath);
            return jsonString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void WriteDataInFile(string fileName, double[] data, int bucketIndex)
        {
            // Create a local file in the ./data/ directory for uploading and downloading
            string localfilePath = Path.Combine(Experiment.DataFolder, fileName);

            if (!File.Exists(localfilePath))
            {
                File.Create(localfilePath);
            }

            StreamWriter sw = File.AppendText(localfilePath);
            
            try
            {
                sw.WriteLine();
                sw.WriteLine("*************--Processing started--************");
                sw.Write("For bucket index : " + bucketIndex + " -> ");
                foreach (var d in data)
                {
                    sw.Write(d + "  ");
                }
            }
            finally
            {
                sw.WriteLine();
                sw.WriteLine("*************--Processing ended--************");
                sw.WriteLine();
                sw.Flush();
                sw.Close(); 
            }

           
        }
    }
}