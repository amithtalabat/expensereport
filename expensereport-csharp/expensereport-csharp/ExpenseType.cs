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

        public static readonly ExpenseType Dinner = new(Type.DINNER, "Dinner", true);

        public static readonly ExpenseType Breakfast = new(Type.BREAKFAST, "Breakfast", true);

        public static readonly ExpenseType CarRental = new(Type.CAR_RENTAL, "Car Rental", false);

        private readonly Type _type;
        private readonly string _name;
        private readonly bool _isMeal;

        private ExpenseType(Type type, string name, bool isMeal)
        {
            _type = type;
            _name = name;
            _isMeal = isMeal;
        }

        public string ExpenseMarker(int amount)
        {
            var mealOverExpensesMarker =
                _type == Type.DINNER && amount > 5000 ||
                _type == Type.BREAKFAST && amount > 1000
                    ? "X"
                    : " ";
            return mealOverExpensesMarker;
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