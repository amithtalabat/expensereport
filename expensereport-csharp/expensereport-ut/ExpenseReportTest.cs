using System;
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
            var now = DateTime.Now;
            var report = new DummyExpenseReport
            {
                _dateTime = now
            };

            report.PrintReport(new List<Expense>());
            Assert.AreEqual($"Expenses {now}",report._messages[0]);
            Assert.AreEqual("Meal expenses: 0",report._messages[1]);
            Assert.AreEqual("Total expenses: 0",report._messages[2]);
        }
        
        [Test]
        public void ExpenseReportForDinerExpense()
        {
            var now = DateTime.Now;
            var report = new DummyExpenseReport
            {
                _dateTime = now
            };

            var dinnerExpense = new Expense(){amount = 10,type = ExpenseType.DINNER};
            report.PrintReport(new List<Expense>() { dinnerExpense });
            Assert.AreEqual($"Expenses {now}",report._messages[0]);
            Assert.AreEqual($"Dinner\t{dinnerExpense.amount}\t ",report._messages[1]);
            Assert.AreEqual($"Meal expenses: {dinnerExpense.amount}",report._messages[2]);
            Assert.AreEqual($"Total expenses: {dinnerExpense.amount}",report._messages[3]);
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