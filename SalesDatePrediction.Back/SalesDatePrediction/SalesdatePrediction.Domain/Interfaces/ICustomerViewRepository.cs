using SalesdatePrediction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Domain.Interfaces
{
    public interface ICustomerViewRepository
    {
        Task<IEnumerable<CustomerView>> GetAll();
    }
}
