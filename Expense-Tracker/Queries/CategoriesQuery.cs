using Expense_Tracker.Common;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Queries
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
    public class CategoriesQuery : IQuery<IEnumerable<Category>>
    {

    }

    public class CategoriesQueryHandler : IQueryHandler<CategoriesQuery, IEnumerable<Category>>
    {
        private readonly ITransactionRepository _transactionRepository;
        public CategoriesQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Category>> HandleAsync(CategoriesQuery query)
        {
            return await _transactionRepository.GetCategoriesAsync();
        }
    }
}
