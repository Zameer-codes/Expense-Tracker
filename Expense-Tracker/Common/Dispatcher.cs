
namespace Expense_Tracker.Common
{
    public class Dispatcher : IDispatcher
    {
        private IServiceProvider _serviceProvider;
        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)query);
        }

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
                await handler.HandleAsync(command);
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
