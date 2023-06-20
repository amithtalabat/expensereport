using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Expenses " + DateTime.Now);

            var mealExpenses = MealExpenses(expenses);

            foreach (var expense in expenses)
            {

                var expenseName = expense.Name();

                var mealOverExpensesMarker = expense.IsMealOverExpense()
                    ? MealOverExpensesMarker
                    : NoMarker;

                Console.WriteLine(ExpenseWithMarker(expenseName, expense, mealOverExpensesMarker));
            }

            var total = Total(expenses);

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static int Total(IEnumerable<Expense> expenses)
        {
            return expenses.Sum(expense => expense.amount);
        }

        private static int MealExpenses(IEnumerable<Expense> expenses)
        {
            return expenses.Where(expense => expense.IsMeal()).Sum(expense => expense.amount);
        }

        private static string ExpenseWithMarker(string expenseName, Expense expense, string mealOverExpensesMarker)
        {
            return expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker;
        }
    }
}