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

        public static readonly ExpenseType Dinner = new(Type.DINNER);

        public static readonly ExpenseType Breakfast = new(Type.BREAKFAST);

        public static readonly ExpenseType CarRental = new(Type.CAR_RENTAL);

        private readonly Type _type;

        private ExpenseType(Type type)
        {
            _type = type;
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
            return _type switch
            {
                Type.DINNER => "Dinner",
                Type.BREAKFAST => "Breakfast",
                Type.CAR_RENTAL => "Car Rental",
                _ => ""
            };
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