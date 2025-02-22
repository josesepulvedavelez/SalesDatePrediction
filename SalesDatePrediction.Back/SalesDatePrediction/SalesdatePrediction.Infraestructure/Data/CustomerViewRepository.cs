using Microsoft.EntityFrameworkCore;
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

    }
}
