using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Models.ViewModels;

namespace online_retail.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrder(OrderModel orderModel);
        Task<OrderModel> GetByOrderId(Guid orderId);
        Task<List<OrderModel>> GetAllOrder();
        Task<bool> DeleteOrderById(Guid orderId);

    }

}
