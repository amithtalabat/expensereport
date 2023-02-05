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
            var dinnerExpense = new Expense(10, ExpenseType.DINNER);
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

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
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpense = new Expense(11, ExpenseType.BREAKFAST);
            
            report.PrintReport(new List<Expense>() { dinnerExpense });

            var expected = new List<string>
            {
                $"Expenses {TwentySecondDecember()}",
                $"Breakfast\t{dinnerExpense.Amount}\t ",
                $"Meal expenses: {dinnerExpense.Amount}",
                $"Total expenses: {dinnerExpense.Amount}"
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
            var carRentalExpense = new Expense(130, ExpenseType.CAR_RENTAL);
            
            report.PrintReport(new List<Expense>() { carRentalExpense });

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
                _dateTime = TwentySecondDecember()
            };
            
            var dinnerExpense = new Expense(5001,ExpenseType.DINNER);
            var breakfastExpense = new Expense(9999,ExpenseType.BREAKFAST);
            
            report.PrintReport(new List<Expense>() { dinnerExpense, breakfastExpense });

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
                _dateTime = TwentySecondDecember()
            };
            var dinnerExpenseOne = new Expense(71,ExpenseType.DINNER);
            var dinnerExpenseTwo = new Expense(-10, ExpenseType.DINNER);
            var breakFastExpenseOne = new Expense(29, ExpenseType.BREAKFAST);
            var breakFastExpenseTwo = new Expense(-200, ExpenseType.BREAKFAST);
            var carRentalExpenseOne = new Expense(400, ExpenseType.CAR_RENTAL);
            var carRentalExpenseTwo = new Expense(-23, ExpenseType.CAR_RENTAL);
            
            report.PrintReport(new List<Expense>() { dinnerExpenseOne, dinnerExpenseTwo, breakFastExpenseOne, breakFastExpenseTwo, carRentalExpenseOne, carRentalExpenseTwo });

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