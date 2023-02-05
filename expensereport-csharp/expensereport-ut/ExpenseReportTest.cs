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
            var report = new ExpenseReport();
            
            report.PrintReport(new List<Expense>());
        }
    }
}