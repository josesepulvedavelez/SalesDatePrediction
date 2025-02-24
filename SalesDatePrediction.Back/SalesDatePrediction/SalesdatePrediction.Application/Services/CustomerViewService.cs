using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Domain.DTOs;
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

        public Task<int> AddNewOrder(OrderDetailDto orderDetailDto)
        {
            var query = _customerViewRepository.AddNewOrder(orderDetailDto);
            return query;
        }

        public Task<IEnumerable<CustomerView>> GetAll()
        {
            var query = _customerViewRepository.GetAll();
            return query;
        }

        public Task<IEnumerable<OrderDto>> GetClientOders(int cusId)
        {
            var query = _customerViewRepository.GetClientOders(cusId);
            return query;
        }

    }
}
