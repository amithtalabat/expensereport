﻿using System;
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

            PrintCurrentDate();
            
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

                PrintExpenseForAnItem(expenseName, expense, mealOverExpensesMarker);

                total += expense.amount;
            }

            PrintMealExpenses(mealExpenses);
            PrintTotalExpenses(total);
        }

        private static void PrintTotalExpenses(int total)
        {
            Console.WriteLine("Total expenses: " + total);
        }

        private static void PrintMealExpenses(int mealExpenses)
        {
            Console.WriteLine("Meal expenses: " + mealExpenses);
        }

        private static void PrintExpenseForAnItem(string expenseName, Expense expense, string mealOverExpensesMarker)
        {
            Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
        }

        private static void PrintCurrentDate()
        {
            Console.WriteLine("Expenses " + DateTime.Now);
        }
    }
}