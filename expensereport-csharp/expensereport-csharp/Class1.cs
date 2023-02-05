using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public class Expense
    {
        public ExpenseType type;
        public int amount;

        public string ExpenseNameFromExpenseType()
        {
            String expenseName = "";
            switch (type)
            {
                case ExpenseType.DINNER:
                    expenseName = "Dinner";
                    break;
                case ExpenseType.BREAKFAST:
                    expenseName = "Breakfast";
                    break;
                case ExpenseType.CAR_RENTAL:
                    expenseName = "Car Rental";
                    break;
            }

            return expenseName;
        }
    }

    public class ExpenseReport
    {
        public DateTime _dateTime = DateTime.Now;

        public void PrintReport(List<Expense> expenses)
        {
            var total = 0;
            var mealExpenses = 0;

            Print("Expenses " + _dateTime);
            
            foreach (Expense expense in expenses)
            {
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    mealExpenses += expense.amount;
                }

                var expenseName = expense.ExpenseNameFromExpenseType();

                var mealOverExpensesMarker =
                    expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                    expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                        ? "X"
                        : " ";

                Print(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

                total += expense.amount;
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