using Expense_Tracker.Commands;
using Expense_Tracker.Models;
using Expense_Tracker.Queries;
using Expense_Tracker.Queries.Models;


namespace Expense_Tracker.Repositories
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(TransactionModel transaction);
        Task AddCategoryAsync(CategoryModel category);
        Task<IEnumerable<TransactionQueryModel>> GetTransactionsAsync();
        Task<IEnumerable<CategoryQueryModel>> GetCategoriesAsync();
        Task DeleteCategoryByIdAsync(Guid categoryId);
    }
}
