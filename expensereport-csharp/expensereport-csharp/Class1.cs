using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER,
        BREAKFAST,
        CAR_RENTAL
    }

    public class Expense
    {
        public ExpenseType type;
        public int _amount;

        public string Name()
        {
            return new ExpenseTypeDomain(type).Name();
        }

        public string MealLimitMarker()
        {
            return new ExpenseTypeDomain(type).ExpenseMarker(_amount);
        }
    }

    public class ExpenseTypeDomain
    {
        private readonly ExpenseType _type;

        public ExpenseTypeDomain(ExpenseType type)
        {
            _type = type;
        }

        public string ExpenseMarker(int amount)
        {
            var mealOverExpensesMarker =
                _type == ExpenseType.DINNER && amount > 5000 ||
                _type == ExpenseType.BREAKFAST && amount > 1000
                    ? "X"
                    : " ";
            return mealOverExpensesMarker;
        }

        public string Name()
        {
            return _type switch
            {
                ExpenseType.DINNER => "Dinner",
                ExpenseType.BREAKFAST => "Breakfast",
                ExpenseType.CAR_RENTAL => "Car Rental",
                _ => ""
            };
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
                    mealExpenses += expense._amount;
                }

                Print(expense.Name() + "\t" + expense._amount + "\t" + expense.MealLimitMarker());

                total += expense._amount;
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