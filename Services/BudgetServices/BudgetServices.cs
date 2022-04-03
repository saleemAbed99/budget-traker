using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using budgetTracker.Data;
using budgetTracker.Dtos.Budget;
using budgetTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace budgetTracker.Services.BudgetServices
{
    public class BudgetServices : IBudgetServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public BudgetServices(DataContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        private int GetUserID() => int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetBudgetDto>> AddBudget(AddBudgetDto newBudget)
        {
            var response = new ServiceResponse<GetBudgetDto>();

            try
            {
                Budget budget = _mapper.Map<Budget>(newBudget);
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserID());
                budget.User = user;
                _context.Budgets.Add(budget);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetBudgetDto>(budget);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
           
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteBudget(int id)
        {
            var response = new ServiceResponse<string>();

            try
            {
                Budget budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.User.Id == GetUserID());

                if(budget != null)
                {
                    _context.Budgets.Remove(budget);
                    await _context.SaveChangesAsync();
                    response.Data = "Budget deleted successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Budget not found";
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
        
            return response;
        }

        public async Task<ServiceResponse<GetBudgetDto>> GetBudgetDetails(int id)
        {
            var response = new ServiceResponse<GetBudgetDto>();

            try
            {
                var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.User.Id == GetUserID());
                response.Data = _mapper.Map<GetBudgetDto>(budget);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}