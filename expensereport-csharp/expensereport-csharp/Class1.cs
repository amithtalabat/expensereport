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

        public string Name()
        {
            var expenseName = "";
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

        public bool IsDinner()
        {
            return type == ExpenseType.DINNER;
        }

        public bool IsBreakfast()
        {
            return type == ExpenseType.BREAKFAST;
        }

        public bool IsGreaterThan(int amount)
        {
            return this.amount > amount;
        }

        public bool IsOverExpenseDinner()
        {
            return IsDinner() && IsGreaterThan(5000);
        }

        public bool IsOverExpenseBreakfast()
        {
            return IsBreakfast() && IsGreaterThan(1000);
        }

        public bool IsMealOverExpense()
        {
            return IsOverExpenseDinner() ||
                   IsOverExpenseBreakfast();
        }

        public bool IsMeal()
        {
            return IsDinner() || IsBreakfast();
        }
    }

    public class ExpenseReport
    {
        private const string MealOverExpensesMarker = "X";
        private const string NoMarker = " ";

        public static void PrintReport(List<Expense> expenses)
        {
            var total = 0;
            var mealExpenses = 0;

            Console.WriteLine("Expenses " + DateTime.Now);
            
            foreach (var expense in expenses)
            {
                if (expense.IsMeal())
                {
                    mealExpenses += expense.amount;
                }

                var expenseName = expense.Name();

                var mealOverExpensesMarker = expense.IsMealOverExpense()
                        ? MealOverExpensesMarker : NoMarker;

                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

                total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }
    }
}