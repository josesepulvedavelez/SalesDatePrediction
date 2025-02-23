using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Application.Interfaces
{
    public interface ICustomerViewService
    {
        Task<IEnumerable<CustomerView>> GetAll();
        Task<IEnumerable<OrderDto>> GetClientOders(int cusId);
    }
}
