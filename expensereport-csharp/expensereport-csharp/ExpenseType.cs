namespace expensereport_csharp
{
    public class ExpenseType
    {
        public static readonly ExpenseType Dinner = new("Dinner", true, 5000);

        public static readonly ExpenseType Breakfast = new("Breakfast", true, 1000);

        public static readonly ExpenseType CarRental = new("Car Rental", false, int.MaxValue);

        private readonly string _name;
        private readonly bool _isMeal;
        private readonly int _amountLimit;

        private ExpenseType(string name, bool isMeal, int amountLimit)
        {
            _name = name;
            _isMeal = isMeal;
            _amountLimit = amountLimit;
        }

        public string ExpenseMarker(int amount)
        {
            return amount > _amountLimit ? "X" : " ";
        }

        public string Name()
        {
            return _name;
        }

        public bool IsMeal()
        {
            return _isMeal;
        }
    }
}