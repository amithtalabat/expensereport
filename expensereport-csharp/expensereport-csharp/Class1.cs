using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public class ExpenseReport
    {
        public DateTime _dateTime = DateTime.Now;

        public void PrintReport(List<Expense> expenses)
        {
            var total = 0;
            var mealExpenses = 0;

            Print("Expenses " + _dateTime);

            foreach (var expense in expenses)
            {
                if (expense.IsMeal())
                {
                    mealExpenses += expense.Amount;
                }

                Print(expense.Name() + "\t" + expense.Amount + "\t" + expense.MealLimitMarker());

                total += expense.Amount;
            }

            Print("Meal expenses: " + mealExpenses);
            Print("Total expenses: " + total);
        }

        protected virtual void Print(string printedMessage)
        {
            Console.WriteLine(printedMessage);
        }
    }
}