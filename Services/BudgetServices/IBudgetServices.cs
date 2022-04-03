using System.Threading.Tasks;
using budgetTracker.Dtos.Budget;
using budgetTracker.Models;

namespace budgetTracker.Services.BudgetServices
{
    public interface IBudgetServices
    {
         Task<ServiceResponse<GetBudgetDto>> GetBudgetDetails(int id);
         Task<ServiceResponse<GetBudgetDto>> AddBudget(AddBudgetDto newBudget);
         Task<ServiceResponse<string>> DeleteBudget(int id);
    }
}