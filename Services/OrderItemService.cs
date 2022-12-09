using Add_Database_Model.Models;
using DataBaseManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseManegmentSystem.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDBContext _context;

        public OrderItemService(ApplicationDBContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<OrderItem>> GetAllOrderItem()
        {
            return await _context.OrderItems
                .ToListAsync();
        }

    }
}
