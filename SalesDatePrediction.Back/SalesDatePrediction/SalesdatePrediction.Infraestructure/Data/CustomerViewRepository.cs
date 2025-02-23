using Microsoft.EntityFrameworkCore;
using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Entities;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Infraestructure.Data
{
    public class CustomerViewRepository : ICustomerViewRepository
    {
        private readonly StoreSampleContext _sampleContext;

        public CustomerViewRepository(StoreSampleContext storeSampleContext) 
        { 
            _sampleContext = storeSampleContext;
        }

        public async Task<IEnumerable<CustomerView>> GetAll()
        {
            var query = await _sampleContext.CustomerViews.ToListAsync();
            return query;
        }

        public async Task<IEnumerable<OrderDto>> GetClientOders(int cusId)
        {
            var lstOrderDto = new List<OrderDto>();
            var query = await _sampleContext.Orders.Where(x => x.Custid == cusId).ToListAsync();
            
            foreach (var item in query)
            {
                lstOrderDto.Add(new OrderDto
                {
                    Orderid = item.Orderid,
                    Requireddate = item.Requireddate,
                    Shipaddress = item.Shipaddress,
                    Shipcity = item.Shipcity,
                    Shipname = item.Shipname,
                    Shippeddate = item.Shippeddate
                });
            }

            return lstOrderDto;
        }

    }
}
