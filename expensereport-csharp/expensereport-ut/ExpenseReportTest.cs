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
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };

            report.PrintReport(new List<Expense>());

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                "Meal expenses: 0",
                "Total expenses: 0"
            };
            Assert.AreEqual(expected, report._messages);
        }

        [Test]
        public void ExpenseReportForDinerExpense()
        {
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpense = new Expense() { amount = 10, type = ExpenseType.DINNER };
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpense.amount}\t ",
                $"Meal expenses: {dinnerExpense.amount}",
                $"Total expenses: {dinnerExpense.amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }
        
        [Test]
        public void ExpenseReportForBreakFastExpense()
        {
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpense = new Expense() { amount = 11, type = ExpenseType.BREAKFAST };
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Breakfast\t{dinnerExpense.amount}\t ",
                $"Meal expenses: {dinnerExpense.amount}",
                $"Total expenses: {dinnerExpense.amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }
        
        [Test]
        public void ExpenseReportForCarRentalExpense()
        {
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpense = new Expense() { amount = 130, type = ExpenseType.CAR_RENTAL };
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Car Rental\t{dinnerExpense.amount}\t ",
                "Meal expenses: 0",
                $"Total expenses: {dinnerExpense.amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }

        private static DateTime TwentySecondDecember()
        {
            return DateTime.Parse("2022-12-22T00:00:00+0400", null);
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