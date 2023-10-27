using System;
using System.Collections.Generic;
using System.Text;
using XtramileTest.Scripts;
using XtramileTest.Test;
using Xunit;
using Xunit.Abstractions;

namespace XtramileTest.TestRunner
{
    public class TestRunner : InitDriver
    {
        private TestAlert TestAlert;
        private TestDatabase TestDatabase;

        public TestRunner(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            TestAlert = new TestAlert(driver);
            TestDatabase = new TestDatabase(driver);
        }

        [Fact]
        public void TestJSAlert()
        {
            TestAlert.TestJSAlert();
        }

        [Fact]
        public void TestJSConfirm()
        {
            TestAlert.TestJSConfirm();
        }

        [Fact]
        public void TestJSPrompt()
        {
            TestAlert.TestJSPrompt();
        }

        [Fact]
        public void TestDatabaseFilter()
        {
            TestDatabase.FilterComputer();
        }

        [Fact]
        public void TestDatabaseAdd()
        {
            TestDatabase.AddComputer();
        }

        [Fact]
        public void TestDatabaseEdit()
        {
            TestDatabase.EditComputer();
        }

        [Fact]
        public void TestDatabaseDelete()
        {
            TestDatabase.DeleteComputer();
        }

        [Fact]
        public void TestDatabasePagination()
        {
            TestDatabase.PaginationCheck();
        }
    }
}
