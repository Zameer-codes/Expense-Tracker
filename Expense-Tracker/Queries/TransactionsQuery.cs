using Expense_Tracker.Common;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Queries
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public int Amount { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public DateTime TransactionTime { get; set; }
    }
    public class TransactionsQuery:IQuery<IEnumerable<Transaction>>
    {
        
    }

    public class TransactionQueryHandler : IQueryHandler<TransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionQueryHandler(ITransactionRepository transactionRepository) { 
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> HandleAsync(TransactionsQuery query)
        {
            return await _transactionRepository.GetTransactionsAsync();
        }
    }
}
