using System;

namespace MyExperiment.Utilities
{
    public static class StringUtilities
    {
        public static bool isBlankOrNull(string fileName)
        {
            return fileName == null || fileName.Trim().Length == 0;
        }
    }
}