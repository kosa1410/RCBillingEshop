using Microsoft.EntityFrameworkCore;
using RCBillingEshop.Core.Entities.Base;
using RCBillingEshop.Core.Repositories.Base;

namespace RCBillingEshop.Infrastructure.DataStore.Repositories;

public class Repository<T> : IRepository<T>
    where T : Entity
{
    private readonly BillingDbContext _billingDbContext;

    public Repository(BillingDbContext billingDbContext)
    {
        _billingDbContext = billingDbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken token = default)
    {
        await _billingDbContext.Set<T>().AddAsync(entity, token);
        await _billingDbContext.SaveChangesAsync(token);
        return entity;
    }

    public async Task DeleteAsync(T entity, CancellationToken token = default)
    {
        _billingDbContext.Set<T>().Remove(entity);
        await _billingDbContext.SaveChangesAsync(token);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
    {
        return await _billingDbContext.Set<T>().ToListAsync(token);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _billingDbContext.Set<T>().FindAsync(id, token);
    }

    public async Task UpdateAsync(T entity, CancellationToken token = default)
    {
        _billingDbContext.Set<T>().Update(entity);
        await _billingDbContext.SaveChangesAsync(token);
    }
}
