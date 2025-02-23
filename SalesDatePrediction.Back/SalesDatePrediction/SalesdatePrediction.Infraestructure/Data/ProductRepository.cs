using Microsoft.EntityFrameworkCore;
using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Infraestructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreSampleContext _sampleContext;

        public ProductRepository(StoreSampleContext storeSampleContext) 
        { 
            _sampleContext = storeSampleContext;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var lstProductDto = new List<ProductDto>();
            var query = await _sampleContext.Products.ToListAsync();

            foreach (var item in query)
            {
                lstProductDto.Add(new ProductDto 
                { 
                    Productid = item.Productid, Productname = item.Productname 
                });
            }

            return lstProductDto;
        }

    }
}
