using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        { 
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var query = await _productRepository.GetProducts();
            return query;
        }

    }
}
