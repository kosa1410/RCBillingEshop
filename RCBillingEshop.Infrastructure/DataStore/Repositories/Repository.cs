using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public async Task<T> AddAsync(T entity)
    {
        await _billingDbContext.Set<T>().AddAsync(entity);
        await _billingDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _billingDbContext.Set<T>().Remove(entity);
        await _billingDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _billingDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _billingDbContext.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
