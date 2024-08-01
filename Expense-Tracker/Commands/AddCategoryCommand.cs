using AutoMapper;
using Expense_Tracker.Common;
using Expense_Tracker.Models;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Commands
{
    public class AddCategoryCommand : CategoryModel, ICommand
    {
    }

    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public AddCategoryCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task HandleAsync(AddCategoryCommand command)
        {
            CategoryModel category = _mapper.Map<CategoryModel>(command);
            await _transactionRepository.AddCategoryAsync(category);
        }
    }
}
