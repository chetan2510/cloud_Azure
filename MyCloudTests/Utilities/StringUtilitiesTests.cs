using System;
using System.Collections.Generic;
using System.Text;
using MyExperiment.Utilities;
using NUnit.Framework;

namespace MyCloudTests.Utilities
{
    public class StringUtilitiesTests
    {
        /// <summary>
        /// Test Method validates if blank string is passed as the parameter to StringUtilities.
        /// </summary>
        [Test]
        public void TestForStringUtilitiesForBlank()
        {
            Assert.True(StringUtilities.isBlankOrNull(""));
                    
        }
        /// <summary>
        /// Test Method validates if null valued string is passed as the parameter to StringUtilities.
        /// </summary>
        
        [Test]
        public void TestForStringUtilitiesForNull()
        {
            string nullValue = null;
            Assert.True(StringUtilities.isBlankOrNull(nullValue));
                    
        }
        /// <summary>
        /// Test Method validates if string with some value is passed as the parameter to StringUtilities..
        /// </summary>
        [Test]
        public void TestForStringUtilitiesForNonEmpty()
        {
            string nonEmptylValue = "Testing";
            Assert.False(StringUtilities.isBlankOrNull(nonEmptylValue));      
                            
        }
    }
}