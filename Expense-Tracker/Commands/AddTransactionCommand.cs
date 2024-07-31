using Expense_Tracker.Common;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Commands
{
    public class AddTransactionCommand:ICommand
    {
        public Guid TransactionId { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime TransactionTime { get; set; }
    }

    public class AddTransactionCommandHandler : ICommandHandler<AddTransactionCommand>
    {
        public readonly ITransactionRepository _transactionRepository;
        public AddTransactionCommandHandler(ITransactionRepository transactionRepository) 
        { 
            _transactionRepository = transactionRepository;
        }
        public async Task HandleAsync(AddTransactionCommand command)
        {
            await _transactionRepository.AddTransactionAsync(command);
        }
    }
}
