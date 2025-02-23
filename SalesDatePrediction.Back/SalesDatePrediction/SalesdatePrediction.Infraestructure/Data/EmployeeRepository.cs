using Microsoft.EntityFrameworkCore;
using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Infraestructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreSampleContext _sampleContext;

        public EmployeeRepository(StoreSampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var lstEmployeeDto = new List<EmployeeDto>();
            var query = await _sampleContext.Employees.ToListAsync();

            foreach (var item in query)
            {
                lstEmployeeDto.Add(new EmployeeDto
                {
                    Empid = item.Empid,
                    FullName = String.Concat(item.Firstname, " ", item.Lastname)
                });
            }

            return lstEmployeeDto;
        }

    }
}
