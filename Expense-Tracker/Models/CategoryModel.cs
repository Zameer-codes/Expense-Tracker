namespace Expense_Tracker.Models
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
    }
}