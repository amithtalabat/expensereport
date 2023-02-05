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
            var carRentalExpense = new Expense() { amount = 130, type = ExpenseType.CAR_RENTAL };
            
            report.PrintReport(new List<Expense>() { carRentalExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Car Rental\t{carRentalExpense.amount}\t ",
                "Meal expenses: 0",
                $"Total expenses: {carRentalExpense.amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }
        
        [Test]
        public void ExceedsMealLimit()
        {
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };
            
            var dinnerExpense = new Expense() { amount = 5001, type = ExpenseType.DINNER };
            var breakfastExpense = new Expense() { amount = 9999, type = ExpenseType.BREAKFAST };
            
            report.PrintReport(new List<Expense>() { dinnerExpense, breakfastExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpense.amount}\tX",
                $"Breakfast\t{breakfastExpense.amount}\tX",
                "Meal expenses: 15000",
                "Total expenses: 15000"
            };
            Assert.AreEqual(expected, report._messages);
        }
        
        [Test]
        public void ExpenseReportForAllExpenses()
        {
            var report = new DummyExpenseReport
            {
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpenseOne = new Expense() { amount = 71, type = ExpenseType.DINNER };
            var dinnerExpenseTwo = new Expense() { amount = -10, type = ExpenseType.DINNER };
            var breakFastExpenseOne = new Expense() { amount = 29, type = ExpenseType.BREAKFAST };
            var breakFastExpenseTwo = new Expense() { amount = -200, type = ExpenseType.BREAKFAST };
            var carRentalExpenseOne = new Expense() { amount = 400, type = ExpenseType.CAR_RENTAL };
            var carRentalExpenseTwo = new Expense() { amount = -23, type = ExpenseType.CAR_RENTAL };
            
            report.PrintReport(new List<Expense>() { dinnerExpenseOne, dinnerExpenseTwo, breakFastExpenseOne, breakFastExpenseTwo, carRentalExpenseOne, carRentalExpenseTwo });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpenseOne.amount}\t ",
                $"Dinner\t{dinnerExpenseTwo.amount}\t ",
                $"Breakfast\t{breakFastExpenseOne.amount}\t ",
                $"Breakfast\t{breakFastExpenseTwo.amount}\t ",
                $"Car Rental\t{carRentalExpenseOne.amount}\t ",
                $"Car Rental\t{carRentalExpenseTwo.amount}\t ",
                "Meal expenses: -110",
                "Total expenses: 267"
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