namespace Expense_Tracker.Constants
{
    public static class FilePaths
    {        
        public static string BasePath;
        public static string TransactionFile {get{
                return Path.Combine(BasePath, "Transactions.json");
            } }

        public static string CategoryFile
        {
            get
            {
                return Path.Combine(BasePath, "Categories.json");
            }
        }
    }
}
