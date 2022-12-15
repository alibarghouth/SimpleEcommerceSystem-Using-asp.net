using DataBaseManegmentSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseManegmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItem;

        public OrderItemsController(IOrderItemService orderItem)
        {
            _orderItem = orderItem;
        }

        //[HttpGet]
        //public async Task<IActionResult> getOrderItem()
        //{
        //    var item = await _orderItem.GetOrders();
        //    return Ok(item);
        //}
    }
}
