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
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreSampleContext _storeSampleContext;

        public ShipperRepository(StoreSampleContext storeSampleContext) 
        { 
            _storeSampleContext = storeSampleContext;
        }

        public async Task<IEnumerable<ShipperDto>> GetShippers()
        {
            var lstShipperDto = new List<ShipperDto>();
            var query = await _storeSampleContext.Shippers.ToListAsync();

            foreach (var item in query)
            {
                lstShipperDto.Add(new ShipperDto
                {
                    Supplierid = item.Shipperid,
                    Companyname = item.Companyname
                });
            }

            return lstShipperDto;
        }

    }
}
