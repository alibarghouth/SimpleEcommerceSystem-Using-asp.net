using AutoMapper;
using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;
using DataBaseManegmentSystem.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DataBaseManegmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var customer = await _customerService.GetAllCustomer();

                return Ok(customer);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }
           
        }
        [HttpGet("search")]
        public async Task<IActionResult> search(string name)
        {
            try
            {
                var customer = await _customerService.searchProduct(name);
                if (customer.Any())
                {
                    return Ok(customer);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving from database");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            if(customer is null)
            {
                return NotFound("The Custome is not found");
            }

            return Ok(new CustomerJson<Customer>(customer));    
        }

        [HttpGet("CustomerName")]
        public async Task<IActionResult> GetCustomerByName(string lastName)
        {
            var customer = await _customerService.GetCustomerByName(lastName);

            if(customer is null)
            {
                return NotFound("the custome is not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] CustomerDto dto)
        {
            var map =_mapper.Map<Customer>(dto);

            var cutomer = await _customerService.AddCustomer(map);

            return Ok(cutomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustome(int id)
        {
            var customer =await _customerService.GetCustomerById(id);

            if(customer is null)
            {
                return NotFound("the customer is not found");
            }

            var Delete =  _customerService.DeleteCustomer(customer);

            return Ok(Delete);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustome(int id, [FromForm] CustomerDtoUpdate dto)
        {
            var customer = await _customerService.GetCustomerById(id);

            if (customer is null)
            {
                return NotFound("the customer is not found");
            }

            if (dto.LastName != null)
            {
                customer.LastName = dto.LastName;
            }
            if(dto.FirstName != null)
            {
                customer.FirstName =dto.FirstName;
            }
            if(dto.CardId != null)
            {
                customer.CardId = dto.CardId;
            }
            
            var update = _customerService.UpdateCustomer(customer);

            return Ok(update);

        }

    }
}
