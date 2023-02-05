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
        }

        class DummyExpenseReport: ExpenseReport
        {
            private readonly List<string> _messages;

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