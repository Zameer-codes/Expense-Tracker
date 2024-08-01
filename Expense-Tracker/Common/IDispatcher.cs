namespace Expense_Tracker.Common
{
    public interface IDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
        //Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand :ICommand<TResult>;
    }
}
