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
            var output = new StringWriter();
            Console.SetOut(output);
            
            var report = new ExpenseReport();
            var expenses = new List<Expense>();
            
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Meal expenses: 0" + Environment.NewLine +
                            "Total expenses: 0" + Environment.NewLine, output.ToString());
        }

        [Test]
        public void DinnerExpense(){
            var output = new StringWriter();
            Console.SetOut(output);
            
            var report = new ExpenseReport();
            var expenses = new List<Expense>();
            expenses.Add(new Expense {type = ExpenseType.DINNER, amount = 5000});
            
            report.PrintReport(expenses);
            Assert.AreEqual("Expenses " + DateTime.Now + Environment.NewLine +
                            "Dinner\t5000\t " + Environment.NewLine +
                            "Meal expenses: 5000" + Environment.NewLine +
                            "Total expenses: 5000" + Environment.NewLine, output.ToString());
        }
        
    }
}