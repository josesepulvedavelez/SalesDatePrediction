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
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository) 
        { 
            _shipperRepository = shipperRepository;
        }

        public Task<IEnumerable<ShipperDto>> GetShippers()
        {
            var query = _shipperRepository.GetShippers();
            return query;
        }

    }
}
