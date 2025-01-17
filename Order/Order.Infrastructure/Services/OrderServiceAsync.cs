using System.Linq.Expressions;
using AutoMapper;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Contracts.Service;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Model.RequestModel;
using Order.ApplicationCore.Model.ResponseModel;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync,IMapper mapper)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
    }
    public Task<int> SaveNewOrderAsync(OrderRequestModel model)
    {
        Orders item = _mapper.Map<Orders>(model);
        return _orderRepositoryAsync.InsertAsync(item);
    }

    public Task<int> UpdateOrderAsync(int id, OrderRequestModel model)
    {
        if (id == model.Id)
        {
            Orders item = _mapper.Map<Orders>(model);
            return _orderRepositoryAsync.UpdateAsync(item);
        }
        return Task.Run(() => { return 0; });
    }

    public Task<int> DeleteOrderAsync(int id)
    {
        return _orderRepositoryAsync.DeleteAsync(id);
    }

    public async Task<OrderResponseModel> GetOrderByIdAsync(int id)
    {
        var item = await _orderRepositoryAsync.GetByIdAsync(id);
        if (item != null)
        {
            return _mapper.Map<OrderResponseModel>(item);
        }

        return null;
    }

    public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
    {
        var collection = await _orderRepositoryAsync.GetAllAsync();
        List<OrderResponseModel> orders = _mapper.Map<List<OrderResponseModel>>(collection);
        return orders;
    }

    public async Task<IEnumerable<OrderResponseModel>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var collection = await _orderRepositoryAsync.GetByCustomerIdAsync(customerId);
        List<OrderResponseModel> orders = _mapper.Map<List<OrderResponseModel>>(collection);
        return orders;
    }
}