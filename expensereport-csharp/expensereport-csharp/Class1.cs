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
    }

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            int total = 0;
            int mealExpenses = 0;

            PrintReportDate();
            
            foreach (Expense expense in expenses)
            {
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    mealExpenses += expense.amount;
                }

                String expenseName = "";
                switch (expense.type)
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

                String mealOverExpensesMarker =
                    expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                    expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                        ? "X"
                        : " ";

                PrintExpense(expense, expenseName, mealOverExpensesMarker);
                total += expense.amount;
            }

            PrintMealExpenses(mealExpenses);
            PrintTotalExpenses(total);
        }

        protected virtual void PrintTotalExpenses(int total)
        {
            Console.WriteLine("Total expenses: " + total);
        }

        protected virtual void PrintMealExpenses(int mealExpenses)
        {
            Console.WriteLine("Meal expenses: " + mealExpenses);
        }

        protected virtual void PrintReportDate()
        {
            Console.WriteLine("Expenses " + DateTime.Now);
        }

        protected virtual void PrintExpense(Expense expense, String expenseName, String mealOverExpensesMarker) 
        {
            Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
        }
    }
}