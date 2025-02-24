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

        public async Task<int> AddNewOrder(OrderDetailDto orderDetailDto)
        {
            try
            {
                using (var transaction = _sampleContext.Database.BeginTransactionAsync())
                {
                    Order order = new Order()
                    {
                        Empid = orderDetailDto.Empid,
                        Shipperid = orderDetailDto.Shipperid,
                        Shipname = orderDetailDto.Shipname,
                        Shipaddress = orderDetailDto.Shipaddress,
                        Shipcity = orderDetailDto.Shipcity,
                        Orderdate = orderDetailDto.Orderdate,
                        Requireddate = orderDetailDto.Requireddate,
                        Shippeddate = orderDetailDto.Shippeddate,
                        Freight = orderDetailDto.Freight,
                        Shipcountry = orderDetailDto.Shipcountry
                    };

                    await _sampleContext.Orders.AddAsync(order);
                    await _sampleContext.SaveChangesAsync();

                    var orderId = order.Orderid;

                    var orderDetail = new OrderDetail()
                    {
                        Orderid = orderId,
                        Productid = orderDetailDto.Productid,
                        Unitprice = orderDetailDto.Unitprice,
                        Qty = orderDetailDto.Qty,
                        Discount = orderDetailDto.Discount
                    };

                    await _sampleContext.OrderDetails.AddAsync(orderDetail);
                    await _sampleContext.SaveChangesAsync();

                    await _sampleContext.Database.CommitTransactionAsync();

                    return 1;
                }
            }
            catch (Exception ex)
            {
                await _sampleContext.Database.RollbackTransactionAsync();
                return 0;
            }
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
