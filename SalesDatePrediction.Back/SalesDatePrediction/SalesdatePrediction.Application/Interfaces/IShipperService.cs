using SalesdatePrediction.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Application.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperDto>> GetShippers();
    }
}
