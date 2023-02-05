using System;
using System.Collections.Generic;
using expensereport_csharp;
using NUnit.Framework;
using static expensereport_csharp.ExpenseType;

namespace Tests
{
    public class ExpenseReportTest
    {
        [Test]
        public void ExpenseReportForNoExpenses()
        {
            var report = new DummyExpenseReport
            {
                DateTime = TwentySecondDecember()
            };

            var expenses = new List<Expense>();
            report.PrintReport(new Expenses(expenses));

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
                DateTime = TwentySecondDecember()
            };
            var dinnerExpense = new Expense(10, Dinner);

            List<Expense> expenses = new List<Expense>() { dinnerExpense };
            report.PrintReport(new Expenses(expenses));

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpense.Amount}\t ",
                $"Meal expenses: {dinnerExpense.Amount}",
                $"Total expenses: {dinnerExpense.Amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }

        [Test]
        public void ExpenseReportForBreakFastExpense()
        {
            var report = new DummyExpenseReport
            {
                DateTime = TwentySecondDecember()
            };
            var breakfastExpense = new Expense(11, Breakfast);

            List<Expense> expenses = new List<Expense>() { breakfastExpense };
            report.PrintReport(new Expenses(expenses));

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Breakfast\t{breakfastExpense.Amount}\t ",
                $"Meal expenses: {breakfastExpense.Amount}",
                $"Total expenses: {breakfastExpense.Amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }

        [Test]
        public void ExpenseReportForCarRentalExpense()
        {
            var report = new DummyExpenseReport
            {
                DateTime = TwentySecondDecember()
            };
            var carRentalExpense = new Expense(130, CarRental);

            List<Expense> expenses = new List<Expense>() { carRentalExpense };
            report.PrintReport(new Expenses(expenses));

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Car Rental\t{carRentalExpense.Amount}\t ",
                "Meal expenses: 0",
                $"Total expenses: {carRentalExpense.Amount}"
            };
            Assert.AreEqual(expected, report._messages);
        }

        [Test]
        public void ExceedsMealLimit()
        {
            var report = new DummyExpenseReport
            {
                DateTime = TwentySecondDecember()
            };

            var dinnerExpense = new Expense(5001, Dinner);
            var breakfastExpense = new Expense(9999, Breakfast);

            List<Expense> expenses = new List<Expense>() { dinnerExpense, breakfastExpense };
            report.PrintReport(new Expenses(expenses));

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpense.Amount}\tX",
                $"Breakfast\t{breakfastExpense.Amount}\tX",
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
                DateTime = TwentySecondDecember()
            };
            var dinnerExpenseOne = new Expense(71, Dinner);
            var dinnerExpenseTwo = new Expense(-10, Dinner);
            var breakFastExpenseOne = new Expense(29, Breakfast);
            var breakFastExpenseTwo = new Expense(-200, Breakfast);
            var carRentalExpenseOne = new Expense(400, CarRental);
            var carRentalExpenseTwo = new Expense(-23, CarRental);

            List<Expense> expenses = new List<Expense>()
            {
                dinnerExpenseOne, dinnerExpenseTwo, breakFastExpenseOne, breakFastExpenseTwo, carRentalExpenseOne,
                carRentalExpenseTwo
            };
            report.PrintReport(new Expenses(expenses));

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Dinner\t{dinnerExpenseOne.Amount}\t ",
                $"Dinner\t{dinnerExpenseTwo.Amount}\t ",
                $"Breakfast\t{breakFastExpenseOne.Amount}\t ",
                $"Breakfast\t{breakFastExpenseTwo.Amount}\t ",
                $"Car Rental\t{carRentalExpenseOne.Amount}\t ",
                $"Car Rental\t{carRentalExpenseTwo.Amount}\t ",
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