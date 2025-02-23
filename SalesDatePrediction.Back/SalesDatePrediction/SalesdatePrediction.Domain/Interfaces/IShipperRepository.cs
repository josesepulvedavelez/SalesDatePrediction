using SalesdatePrediction.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Domain.Interfaces
{
    public interface IShipperRepository
    {
        Task<IEnumerable<ShipperDto>> GetShippers();
    }
}
