using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MyExperiment.Utilities;

namespace MyCloudTests.Utilities
{
    public class FlexComRowMatrixTest
    {
        FlexComRowMatrixUtility<object> weightMatrix = new FlexComRowMatrixUtility<object>();

        /// <summary>
        /// Test Method validates if object which is not null is passed as the parameter to FlexComRowMatrixUtility.
        /// </summary>
        [Test]
        public void TestIfObjectIsNotNull()
        {
            Assert.IsNotNull(weightMatrix);
        }
        /// <summary>
        /// Test Method validates if added data is passed as the parameter to FlexComRowMatrix.
        /// </summary>

        [Test]
        public void TestIfDataIsAdded()
        {
            AddDataToMatrix();
            Assert.AreEqual(1, weightMatrix.Matrix.Count);
            Assert.AreEqual(5, weightMatrix.Matrix[0][1]);
        }

        private void AddDataToMatrix()
        {
            List<object> list = new List<object>();
            list.Add(5);
            list.Add(5);
            list.Add(5);
            weightMatrix.Matrix.Add(list);
        }
    }
}


    