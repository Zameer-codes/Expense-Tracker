namespace Expense_Tracker.Models
{
    public class TransactionModel
    {
        public Guid TransactionId { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
