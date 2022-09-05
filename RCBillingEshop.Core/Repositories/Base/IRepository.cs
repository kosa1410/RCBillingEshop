using RCBillingEshop.Core.Entities.Base;

namespace RCBillingEshop.Core.Repositories.Base;

public interface IRepository<T>
    where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<T> AddAsync(T entity, CancellationToken token = default);
    Task UpdateAsync(T entity, CancellationToken token = default);
    Task DeleteAsync(T entity, CancellationToken token = default);
}
