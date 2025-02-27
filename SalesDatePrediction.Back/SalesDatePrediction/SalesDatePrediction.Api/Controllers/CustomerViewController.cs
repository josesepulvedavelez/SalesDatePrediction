﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Domain.DTOs;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerViewController : ControllerBase
    {
        private readonly ICustomerViewService _customerViewService;

        public CustomerViewController(ICustomerViewService customerViewService) 
        { 
            _customerViewService = customerViewService;
        }

        [HttpPost("AddNewOrder")]
        public async Task<IActionResult> AddNewOrder(OrderDetailDto orderDetailDto)
        { 
            var query = await _customerViewService.AddNewOrder(orderDetailDto);
            return Ok(query);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        { 
            var query = await _customerViewService.GetAll();
            return Ok(query);
        }

        [HttpGet("GetClientOrders/{cusId}")]
        public async Task<IActionResult> GetClientOrders(int cusId)
        { 
            var query = await _customerViewService.GetClientOders(cusId);
            return Ok(query);
        }

    }
}
