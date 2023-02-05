namespace expensereport_csharp
{
    public class Expense
    {
        public readonly int Amount;
        private readonly ExpenseType _expenseType;

        public Expense(int amount, ExpenseType expenseType)
        {
            Amount = amount;
            _expenseType = expenseType;
        }

        private string Name()
        {
            return _expenseType.Name();
        }

        private string MealLimitMarker()
        {
            return _expenseType.ExpenseMarker(Amount);
        }

        public bool IsMeal()
        {
            return _expenseType.IsMeal();
        }

        public override string ToString()
        {
            return Name() + "\t" + Amount + "\t" + MealLimitMarker();
        }
    }
}