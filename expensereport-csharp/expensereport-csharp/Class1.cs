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
        public readonly ExpenseType Type;
        public readonly int Amount;

        public Expense(int amount, ExpenseType type) 
        {
            Amount = amount;
            Type = type;
        }

        public string Name()
        {
            return new ExpenseTypeDomain(Type).Name();
        }

        public string MealLimitMarker()
        {
            return new ExpenseTypeDomain(Type).ExpenseMarker(Amount);
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

        public bool IsDinner()
        {
            return _type == ExpenseType.DINNER;
        }

        public bool IsBreakfast()
        {
            return _type == ExpenseType.BREAKFAST;
        }

        public bool IsMeal()
        {
            return IsDinner() || IsBreakfast();
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

            foreach (var expense in expenses)
            {
                if (new ExpenseTypeDomain(expense.Type).IsMeal())
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