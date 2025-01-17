using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class OrderRepositoryAsync:BaseRepositoryAsync<Orders>,IOrderRepositoryAsync
{
    public OrderRepositoryAsync(OrderDbContext dbContext):base(dbContext)
    {
    }
}