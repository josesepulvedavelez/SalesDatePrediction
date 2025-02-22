using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Domain.Entities;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Application.Services
{
    public class CustomerViewService : ICustomerViewService
    {
        private readonly ICustomerViewRepository _customerViewRepository;

        public CustomerViewService(ICustomerViewRepository customerViewRepository) 
        { 
            _customerViewRepository = customerViewRepository;
        }

        public Task<IEnumerable<CustomerView>> GetAll()
        {
            var query = _customerViewRepository.GetAll();
            return query;
        }

    }
}
