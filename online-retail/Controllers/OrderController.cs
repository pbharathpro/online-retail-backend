using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_retail.Models.ViewModels;
using online_retail.Services.Implementation;
using online_retail.Services.Interface;

namespace online_retail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("createOrder")]
        public async Task<IActionResult>CreateOrder([FromBody] OrderModel orderModel)
        {
            OrderModel result = await _orderService.CreateOrder(orderModel);
            return Ok(result);
        }
        [HttpGet("getByOrderId/{{id}}")]
        public async Task<IActionResult> GetByOrderId(Guid orderId)
        {
            OrderModel order = await _orderService.GetByOrderId(orderId);
            return Ok(order);
        }
        [HttpGet("getAllOrder")]
        public async Task<IActionResult>GetAllOrder()
        {
            List<OrderModel> result = await _orderService.GetAllOrder();
            return Ok(result);
        }
        [HttpDelete("deleteProduct/{{id}}")]
        public async Task<IActionResult> DeleteOrderById(Guid id)
        {
            bool isDeleted = await _orderService.DeleteOrderById(id);

            if (!isDeleted)
                return NotFound(new { message = "Order not found" });

            return Ok(new { message = "Order deleted successfully" });
        }
    }
}
