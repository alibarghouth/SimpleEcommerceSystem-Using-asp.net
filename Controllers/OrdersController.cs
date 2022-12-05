using AutoMapper;
using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;
using DataBaseManegmentSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseManegmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _order;

        private readonly IMapper _mapper;

        private readonly IProductService _product;

        public OrdersController(IOrderService order, IMapper mapper, IProductService product)
        {
            _order = order;
            _mapper = mapper;
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var order = await _order.GetAllAsync();

            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _order.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> addOrder(OrderDto dto)
        {
            var map = _mapper.Map<Order>(dto);

            await _order.addOrder(map);

            return Ok(map);    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order =await _order.GetOrderById(id);

            _order.DeleteOrder(order);

            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> Updateorder(int id,[FromForm] OrderDto dto)
        {
            var order = await _order.GetOrderById(id);

            order.Name = dto.Name;
            var update = _order.UpdateOrder(order);

            //var map = _mapper.Map<update>(dto);

            return Ok(update);
        }

    }
}
