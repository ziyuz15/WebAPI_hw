using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class OrderRepositoryAsync:BaseRepositoryAsync<Orders>,IOrderRepositoryAsync
{
    private readonly OrderDbContext _dbContext;

    public OrderRepositoryAsync(OrderDbContext dbContext):base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public new async Task<IEnumerable<Orders>> GetAllAsync()
    {
        return await _dbContext.Set<Orders>()
            .Include(o => o.OrderDetails) // Include navigation property
            .ToListAsync();
    }

    public async Task<IEnumerable<Orders>> GetByCustomerIdAsync(int customerId)
    {
        return await _dbContext.Set<Orders>().Include(o => o.OrderDetails).Where(o => o.CustomerId == customerId).ToListAsync();
    }
}