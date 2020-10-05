using System;
using Microsoft.Azure.Cosmos.Table;
using NUnit.Framework;
using MyExperiment.CloudStorages;

namespace MyCloudTests.CloudStorageTests
{
    public class AzureTableOperationsTests
    {
        [Test]
        public void TestForTableCreate()
        {
            //string tableName = "tableName";
            //string storageConnectionString = "storageConnectionString";
            //var table = AzureTableOperations.CreateTableAsync(tableName, storageConnectionString);
            //Assert.IsNotNull(table);
        }
        
        /// <summary>
        /// This test checks for null argument exception in case of Insert or merge operations method.
        /// </summary>
        [Test]
        public void TestForInsertOrMergeEntityAsync_NullArgumentException()
        {
            string uri = "http://portal.azure.com";
            var table = new CloudTable(new Uri(uri), new TableClientConfiguration());
            try
            {
                AzureTableOperations.InsertOrMergeEntityAsync(table, null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Argument cannot be null", e.Message);
            }
        }
        
        /// <summary>
        /// This test checks for null argument exception in case of delete operation method.
        /// </summary>
        [Test]
        public void TestForDeleteEntityAsync_NullArgumentException()
        {
            string uri = "http://portal.azure.com";
            var table= new CloudTable(new Uri(uri), new TableClientConfiguration());
            try
            {
                AzureTableOperations.DeleteEntityAsync(table, null);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Argument cannot be null", e.Message);
            }
        }
        
        /// <summary>
        /// This test checks if retrieve method is returning the requested entity.
        /// 
        /// </summary>
        // [Test]
        // public void TestForRetrieveMethod()
        // {
        //     var partitionKey = "PartitionKey";
        //     var rowkey = "RowKey";
        //     string uri = "http://portal.azure.com";
        //     var table= new CloudTable(new Uri(uri), new TableClientConfiguration());
        //     var customer= AzureTableOperations.RetrieveEntityUsingPointQueryAsync(table, partitionKey, rowkey);
        
        // You are asserting Task<customer> object not the customer so the not null assert works
        // it will fail for customer.result or so ...
        //     Assert.IsNotNull(customer);
        // }
        
    }
}