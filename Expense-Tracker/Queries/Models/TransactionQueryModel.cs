namespace Expense_Tracker.Queries.Models
{
    public class TransactionQueryModel
    {
        public Guid TransactionId { get; set; }
        public int Amount { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
