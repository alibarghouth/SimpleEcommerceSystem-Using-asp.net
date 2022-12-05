using Add_Database_Model.Models;
using DataBaseManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseManegmentSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDBContext _context;

        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> addOrder(Order order)
        {
            var orders = await _context.Orders.AddAsync(order);

            _context.SaveChanges();

            return order;
        }

        public Order DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);

            _context.SaveChanges();

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var emp = await _context.Orders.ToListAsync();
            return emp;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order =await _context.Orders.FindAsync(id);

            return order;
        }

        public async Task<bool> IsValid(int id)
        {
           return await _context.Orders.AnyAsync(x => x.Id == id);
        }

        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);

            _context.SaveChanges();

            return order;
        }
    }
}
