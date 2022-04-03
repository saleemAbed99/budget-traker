using AutoMapper;
using budgetTracker.Dtos.Budget;
using budgetTracker.Models;

namespace budgetTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Budget, GetBudgetDto>();
            CreateMap<AddBudgetDto, Budget>();
        }
    }
}