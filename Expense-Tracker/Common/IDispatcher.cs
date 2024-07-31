namespace Expense_Tracker.Common
{
    public interface IDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query);
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
