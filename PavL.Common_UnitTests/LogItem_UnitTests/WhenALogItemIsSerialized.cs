using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PavL.Common;

namespace PavL.Common_UnitTests.LogItem_UnitTests
{
    [TestClass]
    public class WhenALogItemIsSerialized
    {
        public string SerializedLogItem { get; set; }


        [TestInitialize]
        public void Init()
        {
            var logItem = new LogItem();

            logItem.Serverity = ServerityLevel.Error;
            logItem.Summary = "This is the test summary";
            logItem.Details = "These are the test details";

            SerializedLogItem = logItem.Serialize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(SerializedLogItem.Contains("Summary"));
            Assert.IsTrue(SerializedLogItem.Contains("details"));
        }
    }
}
