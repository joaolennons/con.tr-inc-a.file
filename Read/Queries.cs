namespace Read
{
    internal static class Queries
    {
        public static class Barbecues
        {
            public const string GetAll = "SELECT Id, Date, Description, Observation FROM Barbecues";
            public static string OrderDesc(string field) => $"ORDER BY {field} desc";
        }
    }
}
