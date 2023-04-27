using System.Collections.Generic;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoExpenses()
        {
            ExpenseReport report = new ExpenseReport();
            report.PrintReport(new List<Expense>());
        }
    }
}