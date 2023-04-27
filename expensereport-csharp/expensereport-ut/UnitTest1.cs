using System.Collections.Generic;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class TestableExpenseReport : ExpenseReport
    {
        public int mealExpenses;
        public int total;
        public Expense expense;
        public string expenseName;
        public string mealOverExpensesMarker;
        
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
        
        protected override void PrintExpense(Expense expense, string expenseName, string mealOverExpensesMarker)
        {
            this.expense = expense;
            this.expenseName = expenseName;
            this.mealOverExpensesMarker = mealOverExpensesMarker;
            base.PrintExpense(expense, expenseName, mealOverExpensesMarker);
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

        [Test]
        public void OneExpense()
        {
            TestableExpenseReport report = new TestableExpenseReport();
            Expense expense = new Expense(){type = ExpenseType.DINNER, amount = 1};
            report.PrintReport(new List<Expense>()
            {
                expense
            });
            
            Assert.AreEqual(1, report.total);
            Assert.AreEqual(1, report.mealExpenses);
            Assert.AreEqual(expense, report.expense);
            Assert.AreEqual("Dinner", report.expenseName);
            Assert.AreEqual(" ", report.mealOverExpensesMarker);
        }
    }
}