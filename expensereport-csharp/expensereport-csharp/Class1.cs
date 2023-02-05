using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public class ExpenseReport
    {
        public DateTime DateTime = DateTime.Now;

        public void PrintReport(List<Expense> expenses)
        {
            var expensesDomain = new Expenses(expenses);
            
            Print("Expenses " + DateTime);
            Print(expensesDomain.ToStrings());
            Print("Meal expenses: " + expensesDomain.MealExpenses());
            Print("Total expenses: " + expensesDomain.Total());
        }

        private void Print(List<string> expensesToPrint)
        {
            foreach (var expense in expensesToPrint)
            {
                Print(expense);
            }
        }

        protected virtual void Print(string printedMessage)
        {
            Console.WriteLine(printedMessage);
        }
    }

    public class Expenses
    {
        public List<Expense> _expenses;

        public Expenses(List<Expense> expenses)
        {
            _expenses = expenses;
        }

        public int Total()
        {
            var total = 0;
            foreach (var expense in _expenses)
            {
                total += expense.Amount;
            }

            return total;
        }

        public List<string> ToStrings()
        {
            return _expenses.Select(expense => expense.ToString()).ToList();
        }

        public int MealExpenses()
        {
            var mealExpenses = 0;
            foreach (var expense in _expenses)
            {
                if (expense.IsMeal())
                {
                    mealExpenses += expense.Amount;
                }
            }

            return mealExpenses;
        }
    }
}