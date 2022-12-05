using DataBaseManegmentSystem.Models;

namespace DataBaseManegmentSystem.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetAllAsync();

        public Task<Order> GetOrderById(int id);

        public Task<Order> addOrder(Order order);

        public Order DeleteOrder(Order order);

        public Order UpdateOrder(Order order);

        public Task<bool> IsValid(int id);
    }
}
