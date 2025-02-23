using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Domain.DTOs;
using SalesdatePrediction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesdatePrediction.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) 
        { 
            _employeeRepository = employeeRepository;
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var query = _employeeRepository.GetEmployees();
            return query;
        }

    }
}
