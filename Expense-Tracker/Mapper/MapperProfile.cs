using AutoMapper;
using Expense_Tracker.Commands;
using Expense_Tracker.Queries;

namespace Expense_Tracker.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AddCategoryCommand, Category>();
        }
    }
}
