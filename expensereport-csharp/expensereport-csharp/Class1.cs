using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public class ExpenseReport
    {
        public DateTime DateTime = DateTime.Now;

        public void PrintReport(Expenses expenses)
        {
            Print("Expenses " + DateTime);
            Print(expenses.ToStrings());
            Print("Meal expenses: " + expenses.MealExpenses());
            Print("Total expenses: " + expenses.Total());
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
}