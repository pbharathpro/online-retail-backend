using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Interface;

namespace online_retail.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> GetByOrderId(Guid orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<List<Order>>GetAllOrder()
        {
           return await _dbContext.Orders.ToListAsync();
        }
        public async Task<bool> DeleteOrderById(Guid orderId)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(u => u.OrderId == orderId);
            if (order == null) return false;

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<User> UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
    
    }
