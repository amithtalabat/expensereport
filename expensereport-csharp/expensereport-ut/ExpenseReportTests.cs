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
    }
}