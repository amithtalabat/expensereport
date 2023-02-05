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

        public static readonly ExpenseType Dinner = new(Type.DINNER, "Dinner");

        public static readonly ExpenseType Breakfast = new(Type.BREAKFAST, "Breakfast");

        public static readonly ExpenseType CarRental = new(Type.CAR_RENTAL, "Car Rental");

        private readonly Type _type;
        private readonly string _name;

        private ExpenseType(Type type, string name)
        {
            _type = type;
            _name = name;
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

        private bool IsDinner()
        {
            return _type == Type.DINNER;
        }

        private bool IsBreakfast()
        {
            return _type == Type.BREAKFAST;
        }

        public bool IsMeal()
        {
            return IsDinner() || IsBreakfast();
        }
    }
}