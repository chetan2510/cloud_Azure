namespace MyExperiment.Utilities
{
    public static class ArrayUtils
    {
        /**
         * Returns the maximum value in the specified array
         * @param array
         * @return
         */
        public static int max(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        
        
        /**
         * Returns the sum of all contents in the specified array.
         * @param array
         * @return
         */
        public static double sum(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}