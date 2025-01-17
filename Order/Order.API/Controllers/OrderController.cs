using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Contracts.Service;
using Order.ApplicationCore.Model.RequestModel;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            _orderServiceAsync = orderServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(_orderServiceAsync.GetAllOrdersAsync());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var result = await _orderServiceAsync.GetOrdersByCustomerIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewOrder(OrderRequestModel model)
        {
            var result = await _orderServiceAsync.SaveNewOrderAsync(model);
            if (result > 0)
            {
                return Ok("Product has been added successfully");
            }

            return BadRequest(result);
        }
        
       
        
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderServiceAsync.DeleteOrderAsync(id);
            if (result > 0)
            {
                return Ok("Product has been deleted successfully");
            }

            return BadRequest(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int id, OrderRequestModel model)
        {
            var result = await _orderServiceAsync.UpdateOrderAsync(id, model);
            if (result > 0)
            {
                return Ok("Product has been updated successfully");
            }

            return BadRequest(result);
        }
    }
}
