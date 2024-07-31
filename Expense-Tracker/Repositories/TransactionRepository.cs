using AutoMapper;
using Expense_Tracker.Commands;
using Expense_Tracker.Constants;
using Expense_Tracker.Queries;
using System.CodeDom.Compiler;
using System.Text.Json;

namespace Expense_Tracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper _mapper;
        public TransactionRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddTransactionAsync(AddTransactionCommand transaction)
        {
            List<AddTransactionCommand> Transactions = await ReadAllFileData<AddTransactionCommand>(FilePaths.TransactionFile);
            transaction.TransactionId = Guid.NewGuid();
            Transactions.Add(transaction);
            var modifiedJson = JsonSerializer.Serialize(Transactions, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePaths.TransactionFile, modifiedJson);
        }

        public async Task AddCategoryAsync(AddCategoryCommand category)
        {
            List<AddCategoryCommand> Categories = await ReadAllFileData<AddCategoryCommand>(FilePaths.CategoryFile);
            category.CategoryId = Guid.NewGuid();
            Categories.Add(category);
            var modifiedJson = JsonSerializer.Serialize(Categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePaths.CategoryFile, modifiedJson);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            List<AddTransactionCommand> Transactions = await ReadAllFileData<AddTransactionCommand>(FilePaths.TransactionFile);
            List<AddCategoryCommand> Categories = await ReadAllFileData<AddCategoryCommand>(FilePaths.CategoryFile);
            var DetailedTransactions = Transactions.Join(
                    Categories,
                    transaction => transaction.CategoryId,
                    category => category.CategoryId,
                    (transaction, category) => new Transaction()
                    {
                        TransactionId = transaction.TransactionId,
                        Amount = transaction.Amount,
                        CategoryName = category.CategoryName,
                        Type = category.Type,
                        TransactionTime = transaction.TransactionTime
                    }
                );
            return DetailedTransactions;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            List<AddCategoryCommand> Categories = await ReadAllFileData<AddCategoryCommand>(FilePaths.CategoryFile);
            return _mapper.Map<IEnumerable<Category>>(Categories);
        }

        private static async Task<List<T>> ReadAllFileData<T>(string filePath) where T : class
        {
            if(File.Exists(filePath))
            {
                var JsonData = await File.ReadAllTextAsync(filePath);
                List<T> Transactions = JsonSerializer.Deserialize<List<T>>(JsonData) ?? new List<T>();
                return Transactions;
            }
            return [];
        }
    }
}
