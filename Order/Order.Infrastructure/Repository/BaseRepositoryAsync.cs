using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository;

public class BaseRepositoryAsync<T>:IRepositoryAsync<T>where T:class
{
    private readonly OrderDbContext _dbContext;

    public BaseRepositoryAsync(OrderDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var obj = await GetByIdAsync(id);
        if (obj != null)
        {
            _dbContext.Set<T>().Remove(obj);
        }

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(o=> o.CustomerId==id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _dbContext.Set<T>().ToListAsync();
        return result;
    }
    
}