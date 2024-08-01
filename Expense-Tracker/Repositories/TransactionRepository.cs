using AutoMapper;
using Expense_Tracker.Commands;
using Expense_Tracker.Constants;
using Expense_Tracker.Models;
using Expense_Tracker.Queries;
using Expense_Tracker.Queries.Models;
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

        public async Task AddTransactionAsync(TransactionModel transaction)
        {
            List<TransactionModel> Transactions = await ReadAllFileData<TransactionModel>(FilePaths.TransactionFile);
            transaction.TransactionId = Guid.NewGuid();
            Transactions.Add(transaction);
            var modifiedJson = JsonSerializer.Serialize(Transactions, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePaths.TransactionFile, modifiedJson);
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            List<CategoryModel> Categories = await ReadAllFileData<CategoryModel>(FilePaths.CategoryFile);
            category.CategoryId = Guid.NewGuid();
            Categories.Add(category);
            var modifiedJson = JsonSerializer.Serialize(Categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePaths.CategoryFile, modifiedJson);
        }

        public async Task DeleteCategoryByIdAsync(Guid categoryId)
        {
            List<CategoryModel> Categories = await ReadAllFileData<CategoryModel>(FilePaths.CategoryFile);
            Categories.RemoveAll(category => category.CategoryId == categoryId);
            var modifiedJson = JsonSerializer.Serialize(Categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePaths.CategoryFile, modifiedJson);
        }

        public async Task<IEnumerable<TransactionQueryModel>> GetTransactionsAsync()
        {
            List<TransactionModel> Transactions = await ReadAllFileData<TransactionModel>(FilePaths.TransactionFile);
            List<CategoryModel> Categories = await ReadAllFileData<CategoryModel>(FilePaths.CategoryFile);
            var DetailedTransactions = Transactions.Join(
                    Categories,
                    transaction => transaction.CategoryId,
                    category => category.CategoryId,
                    (transaction, category) => new TransactionQueryModel()
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

        public async Task<IEnumerable<CategoryQueryModel>> GetCategoriesAsync()
        {
            List<CategoryModel> Categories = await ReadAllFileData<CategoryModel>(FilePaths.CategoryFile);
            return _mapper.Map<IEnumerable<CategoryQueryModel>>(Categories);
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
