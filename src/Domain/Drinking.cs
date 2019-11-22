namespace Domain
{
    public enum Drinking
    {
        Yes,
        No
    }

    public class DrinkingOptionValue
    {
        public DrinkingOptionValue(decimal notDrinking, decimal drinking)
        {
            Drinking = drinking;
            NotDrinking = notDrinking;
            _instance = this;
        }
        public decimal Drinking { get; }
        public decimal NotDrinking { get; }

        private static DrinkingOptionValue _instance;
        public static DrinkingOptionValue Instance => _instance;
    }
}
