using System;

namespace R2ETien.EFCore.Infrastructure.Repositories;

public interface IRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
