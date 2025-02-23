using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesdatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService) 
        { 
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        { 
            var query = await _employeeService.GetEmployees();
            return Ok(query);
        }

    }
}
