﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wexflow.Tasks.Tests
{
    [TestClass]
    public class ResumeTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void Run()
        {
            int workflowId = 41;

            try
            {
                Helper.StartWorkflowAsync(workflowId);
                Thread.Sleep(500);
                var workflow = Helper.GetWorkflow(workflowId);
                Assert.IsFalse(workflow.IsPaused);
                Helper.SuspendWorkflow(workflowId);
                Thread.Sleep(500);
                workflow = Helper.GetWorkflow(workflowId);
                Assert.IsTrue(workflow.IsPaused);
                Helper.ResumeWorkflow(workflowId);
                Thread.Sleep(500);
                workflow = Helper.GetWorkflow(workflowId);
                Assert.IsFalse(workflow.IsPaused);
                Assert.IsTrue(workflow.IsRunning);
            }
            finally
            {
                Helper.StopWorkflow(workflowId);
            }

        }
    }
}
