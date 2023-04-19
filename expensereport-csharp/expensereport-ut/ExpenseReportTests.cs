using System;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class ExpenseReportTests
    {
        [Test]
        public void NoExpenses()
        {
            var report = new ExpenseReport();
            var expenses = new List<Expense>();
            var output = new StringWriter();
            Console.SetOut(output);
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Meal expenses: 0" + Environment.NewLine +
                            "Total expenses: 0" + Environment.NewLine, output.ToString());
        }

        [Test]
        public void DinnerExpense()
        {
            var report = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new Expense {type = ExpenseType.DINNER, amount = 5000}
            };
            var output = new StringWriter();
            Console.SetOut(output);
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Dinner\t5000\t " + Environment.NewLine +
                            "Meal expenses: 5000" + Environment.NewLine +
                            "Total expenses: 5000" + Environment.NewLine, output.ToString());
        }
        
        [Test]
        public void BreakfastExpense()
        {
            var report = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new Expense {type = ExpenseType.BREAKFAST, amount = 1000}
            };
            var output = new StringWriter();
            Console.SetOut(output);
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Breakfast\t1000\t " + Environment.NewLine +
                            "Meal expenses: 1000" + Environment.NewLine +
                            "Total expenses: 1000" + Environment.NewLine, output.ToString());
        }
        
        [Test]
        public void CarRentalExpense()
        {
            var report = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new Expense {type = ExpenseType.CAR_RENTAL, amount = 10000}
            };
            var output = new StringWriter();
            Console.SetOut(output);
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Car Rental\t10000\t " + Environment.NewLine +
                            "Meal expenses: 0" + Environment.NewLine +
                            "Total expenses: 10000" + Environment.NewLine, output.ToString());
        }
        
        [Test]
        public void MultipleExpenses()
        {
            var report = new ExpenseReport();
            var expenses = new List<Expense>
            {
                new() {type = ExpenseType.DINNER, amount = 5000},
                new() {type = ExpenseType.BREAKFAST, amount = 1000},
                new() {type = ExpenseType.CAR_RENTAL, amount = 10000}
            };
            var output = new StringWriter();
            Console.SetOut(output);
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Dinner\t5000\t " + Environment.NewLine +
                            "Breakfast\t1000\t " + Environment.NewLine +
                            "Car Rental\t10000\t " + Environment.NewLine +
                            "Meal expenses: 6000" + Environment.NewLine +
                            "Total expenses: 16000" + Environment.NewLine, output.ToString());
        }
    }
}