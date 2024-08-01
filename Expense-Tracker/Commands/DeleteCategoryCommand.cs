using Expense_Tracker.Common;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Commands
{
    public class DeleteCategoryCommand:ICommand
    {
        public Guid CategoryId { get; set; }
    }

    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        public DeleteCategoryCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task HandleAsync(DeleteCategoryCommand command)
        {
            await _transactionRepository.DeleteCategoryByIdAsync(command.CategoryId);
        }
    }
}
