using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Interface;
using online_retail.Services.Interface;

namespace online_retail.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;

        }
        public  async Task<OrderModel> CreateOrder(OrderModel orderModel)
        {
            Order order = _mapper.Map<Order>(orderModel);
            order.OrderId = Guid.NewGuid();
            Order ordered = await _orderRepo.CreateOrder(order);
            return _mapper.Map<OrderModel>(ordered);

        }
        public async Task<OrderModel> GetByOrderId(Guid orderId)
        {
            Order order = await _orderRepo.GetByOrderId(orderId);
            OrderModel orderModel = _mapper.Map<OrderModel>(order);

            return orderModel;

        }
        public async Task<List<OrderModel>>GetAllOrder()
        {
            List<Order> orders = await _orderRepo.GetAllOrder();
            List<OrderModel> orderModel = _mapper.Map<List<OrderModel>>(orders);
            return orderModel;
        }
        public async Task<bool> DeleteOrderById(Guid orderId)
        {
            return await _orderRepo.DeleteOrderById(orderId);
        }
    } 
}
