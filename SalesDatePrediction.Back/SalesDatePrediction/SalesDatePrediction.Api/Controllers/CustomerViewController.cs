using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesdatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerViewController : ControllerBase
    {
        private readonly ICustomerViewService _customerViewService;

        public CustomerViewController(ICustomerViewService customerViewService) 
        { 
            _customerViewService = customerViewService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        { 
            var query = await _customerViewService.GetAll();
            return Ok(query);
        }

    }
}
