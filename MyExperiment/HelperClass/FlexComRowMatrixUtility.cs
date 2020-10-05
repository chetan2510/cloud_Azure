using System;
using System.Collections.Generic;

namespace MyExperiment.Utilities
{
    public class FlexComRowMatrixUtility<T>
    {
        public List<List<object>> Matrix = new List<List<object>>();

        public void AddAndUpdate(int row, int column , double value)
        {
            Matrix[row][column] = Convert.ToDouble(Matrix[row][column]) + value;
        }
    }
}
