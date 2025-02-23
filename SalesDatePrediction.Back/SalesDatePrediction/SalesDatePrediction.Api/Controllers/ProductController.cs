using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesdatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        { 
            var query = await _productService.GetProducts();
            return Ok(query);
        }

    }
}
