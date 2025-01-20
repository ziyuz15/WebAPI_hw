using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repository;

public interface IOrderRepositoryAsync:IRepositoryAsync<Orders>
{
    Task<IEnumerable<Orders>> GetByCustomerIdAsync(int customerId);
}