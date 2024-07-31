using Expense_Tracker.Commands;
using Expense_Tracker.Queries;


namespace Expense_Tracker.Repositories
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(AddTransactionCommand transaction);
        Task AddCategoryAsync(AddCategoryCommand category);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
