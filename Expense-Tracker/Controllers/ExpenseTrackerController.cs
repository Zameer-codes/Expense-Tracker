using Expense_Tracker.Commands;
using Expense_Tracker.Common;
using Expense_Tracker.Queries;
using Expense_Tracker.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api")]
    [ApiController]
    public class ExpenseTrackerController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public ExpenseTrackerController(IDispatcher dispatcher)
        {
                _dispatcher = dispatcher;
        }

        [HttpGet("transactions/get")]
        public async Task<IActionResult> GetTransactions()
        {
            var query = new TransactionsQuery();
            var transactions = await _dispatcher.DispatchAsync<TransactionsQuery, IEnumerable<TransactionQueryModel>>(query);
            return Ok(transactions);
        }

        [HttpPost("transaction/add")]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(AddTransaction), new {id=command.TransactionId});
        }

        [HttpGet("categories/get")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new CategoriesQuery();
            var categories = await _dispatcher.DispatchAsync<CategoriesQuery, IEnumerable<CategoryQueryModel>>(query);
            return Ok(categories);
        }
        [HttpPost("category/add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(AddCategory), new { id = command.CategoryId });
        }

        [HttpDelete("category/delete")]
        public async Task<IActionResult> DeleteCategoryById([FromBody] DeleteCategoryCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
