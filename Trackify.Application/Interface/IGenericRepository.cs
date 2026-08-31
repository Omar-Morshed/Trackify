using System;

namespace Trackify.Application.Interface;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    IEnumerable<TEntity> GetAllAsync();
    void Update(TEntity entity);
    Task DeleteAsync(Guid id);
    void Delete(TEntity entity);
}
