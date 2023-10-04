using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _appDbContext;

        public OrderService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //receiving the order with the largest order amount (I assumed that the highest price was meant)
        public async Task<Order> GetOrder()
        {
            return await _appDbContext.Orders.OrderByDescending(o => o.Price).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _appDbContext.Orders.Where(o => o.Quantity > 10).ToListAsync();
        }
    }
}
