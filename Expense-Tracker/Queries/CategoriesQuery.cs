using Expense_Tracker.Common;
using Expense_Tracker.Queries.Models;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Queries
{
    public class CategoriesQuery : IQuery<IEnumerable<CategoryQueryModel>>
    {

    }

    public class CategoriesQueryHandler : IQueryHandler<CategoriesQuery, IEnumerable<CategoryQueryModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        public CategoriesQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<CategoryQueryModel>> HandleAsync(CategoriesQuery query)
        {
            return await _transactionRepository.GetCategoriesAsync();
        }
    }
}
