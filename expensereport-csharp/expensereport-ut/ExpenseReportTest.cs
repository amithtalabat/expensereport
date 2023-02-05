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

            var expected = new List<string>
            {
                $"Expenses {now}",
                "Meal expenses: 0",
                "Total expenses: 0"
            };
            Assert.AreEqual(expected, report._messages);
        }

        [Test]
        public void ExpenseReportForDinerExpense()
        {
            var now = DateTime.Now;
            var report = new DummyExpenseReport
            {
                _dateTime = now
            };
            var dinnerExpense = new Expense() { amount = 10, type = ExpenseType.DINNER };
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

            var expected = new List<string>
            {
                $"Expenses {now}",
                $"Dinner\t{dinnerExpense.amount}\t ",
                $"Meal expenses: {dinnerExpense.amount}",
                $"Total expenses: {dinnerExpense.amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }

        private class DummyExpenseReport : ExpenseReport
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