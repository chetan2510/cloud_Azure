using System;
using MyExperiment.Utilities;
using NUnit.Framework;


namespace MyCloudTests.Utilities
{
    public class ArrayUtilsTests
    {
        /// <summary>
        /// Test Method validates if empty Array is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForEmptyInputArray()
        {
            int[] emptyArray = new int[0];
            Assert.AreEqual(-2147483648, ArrayUtils.max(emptyArray));
        }

        /// <summary>
        /// Test Method validates if Array of positive values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForArrayOfPositiveValues()
        {
            int[] arrayForPositiveValues =new int[5]{3,4,5,7,1};
            Assert.AreEqual(7,ArrayUtils.max(arrayForPositiveValues));

            
            
        }
        /// <summary>
        /// Test Method validates if Array of same positive values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForArrayOfPositiveSameValues()
        {
            
            int[] arrayForPositiveValues =new int[5]{3,3,3,3,3};
            Assert.AreEqual(3,ArrayUtils.max(arrayForPositiveValues));
            
        }
        /// <summary>
        /// Test Method validates if Array of positive and negative values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForArrayOfPositiveNegativeValues()
        {
            int[] arrayForPositiveNegativeValues =new int[5]{-3,-3,-1,4,5};
            Assert.AreEqual(5,ArrayUtils.max(arrayForPositiveNegativeValues));
            
            
        }
        /// <summary>
        /// Test Method validates if sum of Array of positive values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForSumOfArrayOfPositiveValues()
        {
            double[] sumOfArrayForPositiveValues =new Double[5]{3.11,4.22,5.00,7.14,1.90};
            Assert.AreEqual(21.369999999999997d,ArrayUtils.sum(sumOfArrayForPositiveValues));
            
            
        }
        /// <summary>
        /// Test Method validates if sum of Array of same positive values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForSumOfArrayOfPositiveSameValues()
        {
            
            double[] arrayForPositiveValues =new double[5]{3.12,3.12,3.12,3.12,3.12};
            Assert.AreEqual(15.600000000000001d,ArrayUtils.sum(arrayForPositiveValues));
            
        }
        /// <summary>
        /// Test Method validates if sum of Array of positive and negative values is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForSumArrayOfPositiveNegativeValues()
        {
            double[] arrayForPositiveNegativeValues =new double[5]{-3.12,-3.54,-1.00,4.11,5.23};
            Assert.AreEqual(1.6800000000000006d,ArrayUtils.sum(arrayForPositiveNegativeValues));
            
            
        }
        /// <summary>
        /// Test Method validates if sum of empty Array is passed as the parameter to ArrayUtils.
        /// </summary>
        [Test]
        public void TestForArrayUtilsForEmptyInputArraySum()
        {
            double[] emptyArray= new double[0];
            Assert.AreEqual(0,ArrayUtils.sum(emptyArray));
                    
        }
    }
}
