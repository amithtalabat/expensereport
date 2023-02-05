namespace expensereport_csharp
{
    public class ExpenseTypeDomain
    {
        public static readonly ExpenseTypeDomain Dinner = new(ExpenseType.DINNER);
        public static readonly ExpenseTypeDomain Breakfast = new(ExpenseType.BREAKFAST);
        public static readonly ExpenseTypeDomain CarRental = new(ExpenseType.CAR_RENTAL);
        
        public enum ExpenseType
        {
            DINNER,
            BREAKFAST,
            CAR_RENTAL
        }

        public readonly ExpenseType _type;

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
}