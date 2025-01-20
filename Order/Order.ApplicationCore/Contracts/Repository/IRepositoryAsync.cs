using System.Linq.Expressions;
using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repository;

public interface IRepositoryAsync<T> where T:class
{
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    
}