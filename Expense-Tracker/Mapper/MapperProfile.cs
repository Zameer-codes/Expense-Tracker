using AutoMapper;
using Expense_Tracker.Commands;
using Expense_Tracker.Models;
using Expense_Tracker.Queries.Models;

namespace Expense_Tracker.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryModel, CategoryQueryModel>();
            CreateMap<AddCategoryCommand, CategoryModel>();
            CreateMap<AddTransactionCommand, TransactionModel>();
        }
    }
}
