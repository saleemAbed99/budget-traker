using System.Threading.Tasks;
using budgetTracker.Dtos.Budget;
using budgetTracker.Models;
using budgetTracker.Services.BudgetServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace budgetTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetServices _budgetServices;

        public BudgetController(IBudgetServices budgetServices)
        {
            _budgetServices = budgetServices;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<GetBudgetDto>>> AddBudget(AddBudgetDto newBudget)
        {
            var res = await _budgetServices.AddBudget(newBudget);

            if(res == null)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteBudget(int id)
        {
            var res = await _budgetServices.DeleteBudget(id);

            if(res == null)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBudgetDto>>> GetBudgetDetails(int id)
        {
            var res = await _budgetServices.GetBudgetDetails(id);

            if(res == null)
                return BadRequest(res);
            return Ok(res);
        }
    }
}