using AutoMapper;
using Expense_Tracker.Common;
using Expense_Tracker.Models;
using Expense_Tracker.Repositories;

namespace Expense_Tracker.Commands
{
    public class AddTransactionCommand: ICommand
    {
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class AddTransactionCommandHandler : ICommandHandler<AddTransactionCommand>
    {
        public readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public AddTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        { 
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task HandleAsync(AddTransactionCommand command)
        {
            TransactionModel transaction = _mapper.Map<TransactionModel>(command);
            await _transactionRepository.AddTransactionAsync(transaction);
        }
    }
}
