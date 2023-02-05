using System.Collections.Generic;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class ExpenseReportTest
    {
        [Test]
        public void ExpenseReportForNoExpenses()
        {
            var report = new DummyExpenseReport();
            
            report.PrintReport(new List<Expense>());
            Assert.AreEqual("Expenses 02/05/2023 11:42:22",report._messages[0]);
            Assert.AreEqual("Meal expenses: 0",report._messages[1]);
            Assert.AreEqual("Total expenses: 0",report._messages[2]);
        }

        private class DummyExpenseReport: ExpenseReport
        {
            public readonly List<string> _messages;

            public DummyExpenseReport()
            {
                _messages = new List<string>();
            }

            protected override void Print(string printedMessage)
            {
                _messages.Add(printedMessage);
                base.Print(printedMessage);
            }
        }
    }
}