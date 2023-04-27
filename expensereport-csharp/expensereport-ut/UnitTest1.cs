using System.Collections.Generic;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class TestableExpenseReport : ExpenseReport
    {
        public int mealExpenses;
        public int total;
        
        protected override void PrintMealExpenses(int mealExpenses)
        {
            this.mealExpenses = mealExpenses;
            base.PrintMealExpenses(mealExpenses);
        }

        protected override void PrintTotalExpenses(int total)
        {
            this.total = total;
            base.PrintTotalExpenses(total);
        }

        protected override void PrintReportDate()
        {
            base.PrintReportDate();
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoExpenses()
        {
            TestableExpenseReport report = new TestableExpenseReport();
            report.PrintReport(new List<Expense>());
            
            Assert.AreEqual(0, report.total);
            Assert.AreEqual(0, report.mealExpenses);
        }
    }
}