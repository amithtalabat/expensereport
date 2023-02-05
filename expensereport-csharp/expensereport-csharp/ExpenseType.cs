namespace expensereport_csharp
{
    public class ExpenseType
    {
        private enum Type
        {
            DINNER,
            BREAKFAST,
            CAR_RENTAL
        }

        public static readonly ExpenseType Dinner = new(Type.DINNER, "Dinner", true, 5000);

        public static readonly ExpenseType Breakfast = new(Type.BREAKFAST, "Breakfast", true, 1000);

        public static readonly ExpenseType CarRental = new(Type.CAR_RENTAL, "Car Rental", false, int.MaxValue);

        private readonly Type _type;
        private readonly string _name;
        private readonly bool _isMeal;
        private readonly int _amountLimit;

        private ExpenseType(Type type, string name, bool isMeal, int amountLimit)
        {
            _type = type;
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