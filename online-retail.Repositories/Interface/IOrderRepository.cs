using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Repositories.Entities;

namespace online_retail.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetByOrderId(Guid orderId);
        Task<List<Order>> GetAllOrder();
        Task<bool> DeleteOrderById(Guid orderId);


    }
}
