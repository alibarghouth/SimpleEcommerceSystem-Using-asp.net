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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _product;

        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        public ProductsController(IProductService product, IMapper mapper, IOrderService orderService)
        {
            _product = product;
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _product.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _product.GetProductsAsyncById(id);

            if(product == null)
            {
                return NotFound("The product is not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> addProduct([FromForm] ProductDto dto)
        {
            var isValid = await _orderService.IsValid(dto.OrderId);

            if(!isValid)
            {
                return BadRequest("The Order is not Valid");
            }

            using var img = new MemoryStream();
            await dto.ProductImage.CopyToAsync(img);




            var map = _mapper.Map<Product>(dto);
            map.ProductImage = img.ToArray();

            await _product.AddProduct(map);
            return Ok(map);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product =await _product.GetProductsAsyncById(id);

            _product.DeleteProduct(product);

            return Ok(product);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> updateasync(int id,[FromForm] ProductDto dto)
        //{
        //    var product = await _orderService.GetOrderById(id);

        //    product.Name = dto.Name;    
        //    product.DateTime  = 
        //}
    }
}
