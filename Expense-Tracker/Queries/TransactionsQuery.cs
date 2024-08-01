using Expense_Tracker.Common;
using Expense_Tracker.Queries.Models;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Queries
{
    public class TransactionsQuery:IQuery<IEnumerable<TransactionQueryModel>>
    {
    }

    public class TransactionQueryHandler : IQueryHandler<TransactionsQuery, IEnumerable<TransactionQueryModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionQueryHandler(ITransactionRepository transactionRepository) { 
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<TransactionQueryModel>> HandleAsync(TransactionsQuery query)
        {
            return await _transactionRepository.GetTransactionsAsync();
        }
    }
}
