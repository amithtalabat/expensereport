using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public class Expenses
    {
        private readonly List<Expense> _expenses;

        public Expenses(List<Expense> expenses)
        {
            _expenses = expenses;
        }

        public int Total()
        {
            return _expenses.Sum(expense => expense.Amount);
        }

        public List<string> ToStrings()
        {
            return _expenses.Select(expense => expense.ToString()).ToList();
        }

        public int MealExpenses()
        {
            return _expenses.Where(expense => expense.IsMeal()).Sum(expense => expense.Amount);
        }
    }
}