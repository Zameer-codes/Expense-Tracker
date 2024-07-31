using Expense_Tracker.Commands;
using Expense_Tracker.Common;
using Expense_Tracker.Constants;
using Expense_Tracker.Mapper;
using Expense_Tracker.Queries;
using Expense_Tracker.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapperProfile));

// Add services to the container.
builder.Services.AddTransient<ICommandHandler<AddTransactionCommand>, AddTransactionCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
builder.Services.AddTransient <IQueryHandler<TransactionsQuery, IEnumerable<Transaction>>, TransactionQueryHandler>();
builder.Services.AddTransient<IQueryHandler<CategoriesQuery, IEnumerable<Category>>, CategoriesQueryHandler>();
builder.Services.AddScoped<IDispatcher, Dispatcher>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

FilePaths.BasePath = app.Environment.ContentRootPath;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
