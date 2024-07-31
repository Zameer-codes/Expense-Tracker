using Expense_Tracker.Common;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Commands
{
    public class AddCategoryCommand :ICommand
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Type {  get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        public AddCategoryCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task HandleAsync(AddCategoryCommand command)
        {
            await _transactionRepository.AddCategoryAsync(command);
        }
    }
}
