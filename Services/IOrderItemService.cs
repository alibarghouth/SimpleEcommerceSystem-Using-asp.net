using DataBaseManegmentSystem.Models;

namespace DataBaseManegmentSystem.Services
{
    public interface IOrderItemService
    {

        Task<IEnumerable<OrderItem>> GetAllOrderItem();
    }
}
