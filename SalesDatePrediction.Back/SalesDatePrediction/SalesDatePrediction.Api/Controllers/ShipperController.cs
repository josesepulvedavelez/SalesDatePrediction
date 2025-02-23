using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesdatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService) 
        { 
            _shipperService = shipperService;
        }

        [HttpGet("GetShippers")]
        public async Task<IActionResult> GetShippers() 
        { 
            var query = await _shipperService.GetShippers();
            return Ok(query);
        }

    }
}
