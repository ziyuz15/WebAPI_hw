using System.Linq.Expressions;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Model.RequestModel;
using Order.ApplicationCore.Model.ResponseModel;

namespace Order.ApplicationCore.Contracts.Service;

public interface IOrderServiceAsync
{
    Task<int> SaveNewOrderAsync(OrderRequestModel model);
    Task<int> UpdateOrderAsync(int id, OrderRequestModel model);
    Task<int> DeleteOrderAsync(int id);
    Task<OrderResponseModel> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
    Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerIdAsync(int customerId);
}