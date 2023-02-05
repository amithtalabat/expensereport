using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public class ExpenseReport
    {
        public DateTime DateTime = DateTime.Now;

        public void PrintReport(List<Expense> expenses)
        {
            Print("Expenses " + DateTime);

            var expensesDomain = new Expenses(expenses);

            foreach (var expense in expensesDomain._expenses)
            {
                Print(expense.Name() + "\t" + expense.Amount + "\t" + expense.MealLimitMarker());
            }

            Print("Meal expenses: " + MealExpenses(expensesDomain));
            Print("Total expenses: " + expensesDomain.Total());
        }

        private static int MealExpenses(Expenses expensesDomain)
        {
            var mealExpenses = 0;
            foreach (var expense in expensesDomain._expenses)
            {
                if (expense.IsMeal())
                {
                    mealExpenses += expense.Amount;
                }
            }

            return mealExpenses;
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
    }
}