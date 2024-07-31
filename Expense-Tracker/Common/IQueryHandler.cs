namespace Expense_Tracker.Common
{
    public interface IQueryHandler<TQuery, T> where TQuery:IQuery<T>
    {
        Task<T> HandleAsync(TQuery query);
    }
}
